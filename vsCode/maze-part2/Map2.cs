using System;
using System.Collections.Generic;
using System.Text;

class Map2 {
    public int[] _data = new int[25];
    // 값을 외부에서 접근해서 수정하지 못하도록 set을 private으로 설정. 
    public TileType[,] Tile {get; private set;}
    public int Size {get; private set;}
    const char CIRCLE = '\u25cf';
    Player _player;

    public enum TileType 
    {
        Empty,
        Wall,

    }
    // map size를 인자로 받아, 초기화해줌. size는 무조건 홀수여야 함.
    public void Initialize(int size, Player player) {
        
        if(size%2 == 0) {
            // Console.WriteLine("error: only odd number can be inserted as an argument");
            return;
        }
        _player = player;
        Tile = new TileType[size, size];
        Size = size;
        // GenerateByBinaryTree();
        GenerateBySideWinder();
    }

    void GenerateBySideWinder() {
        Console.WriteLine("GenerateBySideWinder() 실행");
    // 정해진 길 막는 작업
        for(int y = 0; y < Size; y++) {
            for(int x = 0; x < Size; x++) {
                // 외곽부분이라면 갈 수 없는 길
                // if(x == 0 || x == Size - 1 || y == 0 ||y == Size - 1)
                //x,y가 짝수인 곳
                if(x%2 == 0 || y%2 == 0)
                    Tile[y,x] = TileType.Wall;
                // 외곽이 아닌 곳은 갈 수 있는 길
                else    
                    Tile[y,x] = TileType.Empty;
            }
        }
        // random으로 길 막는 작업 => 앞에서 막은 길은 continue로 무시
        Random rand = new Random();
        for(int y = 0; y < Size; y++) {
            int cnt = 1;
            for(int x = 0; x < Size; x++) {
                if(x%2 == 0 || y%2 == 0)
                    continue;
                if(y == Size - 2 && x == Size - 2){
                    continue;
                }
                if(y == Size - 2) {
                    Tile[y, x+1] = TileType.Empty;
                    continue;
                }
                if(x == Size - 2) {
                    Tile[y+1, x] = TileType.Empty;
                    continue;
                }
                // 0~(n-1 = 1) 중 랜덤하게 값 전달
                // 0이 나왔으면, 오른쪽으로 한칸 뚫기
                if(rand.Next(0,2) == 0) 
                {
                    Tile[y, x+1] = TileType.Empty;
                    cnt++;
                }
                // 1이 나왔으면, 아래로 한칸 뚫기
                else {
                    int randomIndex = rand.Next(0,cnt);
                    Tile[y + 1, x - randomIndex*2] = TileType.Empty;
                    cnt = 1;
                }
            }
        }
    }
    // 랜더링 부분
    public void Render() {
        ConsoleColor prevColor = Console.ForegroundColor;
        for(int y = 0; y < 25; y++) {
            for(int x = 0; x<25; x++) {
                // 플레이어 좌표를 가져와서, 그 좌표랑 현재 좌표가 일치하면 플레이어 전용 색상으로 표시.
                if(y == _player.PosX && x == _player.PosY){
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                else {
                    Console.ForegroundColor = GetTileColor(Tile[y,x]);
                }
                Console.Write(CIRCLE);
            }
            // enter
            Console.WriteLine();
        }
        Console.ForegroundColor = prevColor;
    }
    // TileType에 따라 색 정해주는 함수
    ConsoleColor GetTileColor(TileType type) {
        switch ( type ) {
            case TileType.Empty:
                return ConsoleColor.Green;
            case TileType.Wall:
                return ConsoleColor.Red;
            default:
                return ConsoleColor.Green;
        }
    }
}