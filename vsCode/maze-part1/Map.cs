using System;
using System.Collections.Generic;
using System.Text;

class Map {
    public int[] _data = new int[25];
    public TileType[,] _tile;
    public int _size;
    const char CIRCLE = '\u25cf';

    public enum TileType 
    {
        Empty,
        Wall,
    }
    // map size를 인자로 받아, 초기화해줌. size는 무조건 홀수여야 함.
    public void Initialize(int size) {
        
        if(size%2 == 0) {
            // Console.WriteLine("error: only odd number can be inserted as an argument");
            return;
        }

        _tile = new TileType[size, size];
        _size = size;
        GenerateByBinaryTree();
    }

    void GenerateByBinaryTree() {
    // 정해진 길 막는 작업
        for(int y = 0; y < _size; y++) {
            for(int x = 0; x < _size; x++) {
                // 외곽부분이라면 갈 수 없는 길
                // if(x == 0 || x == _size - 1 || y == 0 ||y == _size - 1)
                //x,y가 짝수인 곳
                if(x%2 == 0 || y%2 == 0)
                    _tile[y,x] = TileType.Wall;
                // 외곽이 아닌 곳은 갈 수 있는 길
                else    
                    _tile[y,x] = TileType.Empty;
            }
        }
        // random으로 길 막는 작업 => 앞에서 막은 길은 continue로 무시
        Random rand = new Random();
        for(int y = 0; y < _size; y++) {
            for(int x = 0; x < _size; x++) {
                if(x%2 == 0 || y%2 == 0)
                    continue;
                
                if(y == _size - 2 && x == _size - 2)
                    continue;
                // _tile[23, ] 면 아래가 아니라, 무조건 오른쪽으로만 초록색이 번지게 함.
                if(y == _size - 2) {
                    _tile[y, x+1] = TileType.Empty;
                    continue;
                }
                if(x == _size - 2) {
                    _tile[y+1, x] = TileType.Empty;
                    continue;
                }
                // 0~(n-1 = 1) 중 랜덤하게 값 전달
                // 0이 나왔으면, 오른쪽으로 한칸 뚫기
                if(rand.Next(0,2) == 0) 
                {
                    _tile[y, x+1] = TileType.Empty;
                }
                // 1이 나왔으면, 아래로 한칸 뚫기
                else _tile[y+1,x] = TileType.Empty;
            }
        }
    }
    // 랜더링 부분
    public void Render() {
        ConsoleColor prevColor = Console.ForegroundColor;
        for(int y = 0; y < 25; y++) {
            for(int x = 0; x<25; x++) {
                
                Console.ForegroundColor = GetTileColor(_tile[y,x]);
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