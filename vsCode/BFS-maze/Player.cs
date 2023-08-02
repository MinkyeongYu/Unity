class Pos {
    public Pos(int y, int x) {Y=y; X=x;}
    public int Y;
    public int X;
}

// 플레이어 이동 구현
class Player {
    public int PosY {get; private set;}
    public int PosX {get; private set;}
    Random _random = new Random();
    Map2 _m;

    // 0,1,2,3
    enum Dir {
        // 현재 바라보고 있는 방향
        Up, 
        // 왼쪽
        Left,
        // 현재 뒤쪽 방향
        Down, 
        // 오른쪽
        Right
    }
    int _dir = (int)Dir.Up;
    List<Pos> _points = new List<Pos>();

    public void Initialize(int posY, int posX, Map2 map) {
        PosY = posY;
        PosX = posX;
        _m = map;

        // RightHand();
        BFS();
    }
    async void BFS() {
        int[] deltaY = new int[] {-1, 0, 1, 0};
        int[] deltaX = new int[] {0, -1, 0, 1};
        bool[,] found = new bool[_m.Size, _m.Size];
        Pos[,] parent = new Pos[_m.Size, _m.Size];
        Queue<Pos> q = new Queue<Pos>();
        // Pos 생성자 호출하여 Pos의 변수 Y,X를 초기화해주고, initialize하면서 받아온 값 큐에 삽입
        q.Enqueue(new Pos(PosY, PosX));
        found[PosY, PosX] = true;
        parent[PosY, PosX] = new Pos[PosY, PosX];

        while(q.Count>0) {
            Pos pos = q.Dequeue();
            int nowY = pos.Y;
            int nowX = pos.X;

            for(int i = 0; i < 4; i++) {
                int nextY = nowY + deltaY[i];
                int nextX = nowX + deltaX[i];
                
                if(nextX < 0 || nextX >= _m.Size || nextY < 0 || nextY >= _m.Size) continue;
                if(_m.Tile[nextY, nextX == _m.Tile.Wall]) continue;
                if(found[nextY, nextX]) continue;
                // 방문하지 않았거나, 범위를 벗어나지 않았거나, 갈 수 있는 길이라면 큐에 삽입한다.
                q.Enqueue(new Pos(nextY, nextX));
                found[nextY, nextX] = true; 
                parent[nextY, nextX] = new Pos(nowY, nowX);
            }
        }
        int y = _m.DestY;
        int x = _m.DestX;
        // 현재 좌표가 목적지가 아닐 때에만 반복
        // 맨 끝 좌표(목적지)부터 시작좌표까지 거슬러 올라가며 부모를 추적하는 과정. 최단 길찾기 때문에 필요함.
        // 첫번째 검토 : 목적지와 목적지의 부모좌표 비교 => 당연히 좌표가 다름. 따라서, 목적지의 부모 좌표를 y,x에 다시 대입함. 반복.
        while(parent[y,x].Y != y || parent[y, x].X != x) {
            _points.Add(new Pos(y, x));
            Pos pos = parent[y,x];
            y = pos.Y;
            x = pos.X;
        }
        // 시작점은 while문에서 추가 안되기 때문에 따로 추가함.
        _points.Add(new Pos(y, x));
        // list의 순서를 뒤집어서 시작점부터 목적지로 이동하게 함.
        _points.Reverse();
    }
    // 우수법 (오른손 법칙)
    void RightHand() {
        // 현재 바라보고 있는 방향을 기준으로, 좌표 변화를 나타내는 배열
        // 위(map.Tile[PosY-1, ]), 아래([map.Tile[PosY+1, ]])
        int[] frontY = new int[] {-1, 0, 1, 0};
        // 왼쪽(map.Tile[ , PosX-1]), 오른쪽([map.Tile[ , PosX+1]])
        int[] frontX = new int[] {0, -1, 0, 1};
        // 방향 배열
        /* 
               상          좌
            좌    우  => 하   상  =>  ...
               하          우
        */
        // frontY 기준 오른쪽으로 하나씩 이동. (상->우, 좌->상, 하->좌, 우->하 / 마치 시계방향으로 이동) 
        int[] rightY = new int[] {0, -1, 0, 1};
        // frontX 기준 오른쪽으로 하나씩 이동. (동일하게 시계방향으로 이동.)
        int[] rightX = new int[] {1, 0, -1, 0};

        // List에 initial 위치 추가
        _points.Add(new Pos(posY, posX));
        // 목적지에 도달할때까지 반복
        while(PosY != _m.DestY || PosX != _m.DestX) {
            // 1. 현재 바라보는 방향 기준, 오른쪽으로 갈 수 있는지 확인
            if(map.Tile[PosY + rightY[_dir], PosX + rightX[_dir]] == Map2.TileType.Empty) {
                // 각 enum값에 -1을 해준 것으로 유지하도록 함. 
                // 오른쪽 방향으로 90도 회전 (UP->RIGHT, LEFT->UP ...)
                _dir = (_dir - 1 + 4) % 4;
                // 오른쪽 방향으로 90도 회전 후, 앞으로 한 보 전진
                PosY = PosY + frontY[_dir];
                PosX = PosX + frontX[_dir];
                // 앞으로 한 보 전진했으니, 좌표계가 변했을테니까 새로운 좌표도 추가.
                _points.Add(new Pos(posY, posX));
            }
            // 2. 현재 바라보는 방향 기준, 전진할 수 있는지 확인
            else if(map.Tile[PosY + frontY[_dir], PosX + frontX[_dir]] == Map2.TileType.Empty) {
                // 앞으로 한 보 전진
                PosY = PosY + frontY[_dir];
                PosX = PosX + frontX[_dir];
                _points.Add(new Pos(PosY, PosX));
            }  
            // 3. 앞에 벽이 있다면
            else {
                // 왼쪽 방향으로 90도 회전 (UP->LEFT, LEFT->Down ...)
                _dir = (_dir + 1 + 4) % 4;
            }
        } 
    }
    // 100ms = (100 * 0.001)s = 0.1s 
    const int MOVE_TICK = 10;
    int _sumTick = 0;
    int _lastIndex = 0;
    // 0.1s 마다 움직이게 함
    public void Update(int deltaTick) {
        // 배열을 다 돌았으면 아무것도 실행하지 않기
        if(_lastIndex >= _points.Count)
            return;

        _sumTick += deltaTick;
        if(_sumTick >= MOVE_TICK) {
            _sumTick = 0;
            PosY = _points[_lastIndex].Y;
            PosX = _points[_lastIndex].X;
            _lastIndex++;
        }
    }
}