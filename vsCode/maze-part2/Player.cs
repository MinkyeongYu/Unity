// 플레이어 이동 구현
class Player {
    public int PosY {get; private set;}
    public int PosX {get; private set;}
    Random _random = new Random();
    Map2 _m = new Map2();
    public void Initialize(int posY, int posX, int destX, int destY, Map2 map) {
        PosY = posY;
        PosX = posX;
        _m = map;
    }
    // 100ms = (100 * 0.001)s = 0.1s 
    const int MOVE_TICK = 100;
    int _sumTick = 0;
    // 0.1s 마다 움직이게 함
    public void Update(int deltaTick) {
        _sumTick += deltaTick;
        if(_sumTick >= MOVE_TICK) {
            _sumTick = 0;

            // 0.1s마다 실행될 로직 작성
            int randVal = _random.Next(0,5);
            switch(randVal) {
                // 상
                case 0:
                    // 만약 위로 갈 수 있는 경우라면,
                    if(_m.Tile[PosY - 1,PosX] == Map2.TileType.Empty)
                        PosY = PosY - 1;
                    break;
                // 하
                case 1:
                    // 만약 밑으로 갈 수 있는 경우라면,
                    if(_m.Tile[PosY + 1, PosX] == Map2.TileType.Empty)
                        PosY = PosY + 1;
                    break;
                // 좌
                case 2:
                    // 만약 왼쪽으로 갈 수 있는 경우라면,
                    if(_m.Tile[PosY, PosX - 1] == Map2.TileType.Empty)
                        PosX = PosX - 1;
                    break;
                // 우
                case 3:
                    // 만약 오른쪽으로 갈 수 있는 경우라면,
                    if(_m.Tile[PosY, PosX + 1] == Map2.TileType.Empty)
                        PosX = PosX + 1;
                    break;
                case 4: 

                    break;
            }
        }
    }
}