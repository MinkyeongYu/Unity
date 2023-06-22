//  //빌드를 위해 주석처리 함. 
//class BoardM {
//     static void Main(string[] args){
//         Board board = new Board();
//         board.init();
        
//         // 마지막으로 측정한 시간
//         int lastTick = 0;
//         // command 창에서 커서가 안 보이게 함
//         Console.CursorVisible = false;
//         const int WAIT_TICK = 1/30*1000;
//         // 동그라미 표현식
//         const char CIRCLE = '\u25cf';

//         while(true){
            
//             // Fps 프레임 (60프레임->ok, 30프레임 이하->no)
//             #region 프레임 관리
//             // 현재 시간 정보
//             int crnTick = System.Environment.TickCount;

//             // 경과한 시간이 1/30초보다 작다면 -> 단위가 ms라서 1000을 곱해준다.
//             if(crnTick - lastTick < WAIT_TICK)
//                 continue;
//             lastTick = crnTick;
//             #endregion
            
//             // 랜더링
//             // command 창의 커서 위치를 0,0으로 설정
//             Console.SetCursorPosition(0,0);
            
//             for(int i=0; i<25; i++) {
//                 for(int j = 0; j<25; j++) {
//                     // 콘솔 색을 초록색으로 바꿈
//                     Console.ForegroundColor = ConsoleColor.Green;
//                     // 동그라미 (행:25, 열:25) 출력
//                     Console.Write(CIRCLE);
//                 }
//                 // 개행
//                 Console.WriteLine();
//             }
//         }
//     }
// }