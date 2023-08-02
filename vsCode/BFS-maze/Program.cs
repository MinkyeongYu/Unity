class Program {
    static void Main(string[] args){
        Map map = new Map();
        Player _player = new Player();
        map.Initialize(25, _player);
        //  player 시작지점과 목표지점 지정하기
        _player.Initialize(1, 1, map);

        Console.CursorVisible = false;
        const int WAIT_TICK = 1000/30;
        int lastTick = 0;

        // 무한 루프를 원한다면, 인자값으로 true나 1 입력
        while(true) {

            #region 프레임 관리
            // 현재 시간 정보
            int crnTick = System.Environment.TickCount;
            // 경과한 시간이 1/30초보다 작다면 -> 단위가 ms라서 1000을 곱해준다.
            if(crnTick - lastTick < WAIT_TICK)
                continue;
            int deltaTick = crnTick - lastTick;
            lastTick = crnTick;
            #endregion
            
            // 입력

            // 로직
            _player.Update(deltaTick);
            // 랜더링
            Console.SetCursorPosition(0,0);
            map.Render();
        }
    }
}