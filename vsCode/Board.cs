class MyList<T> {
    const int DEFAULT_SIZE = 1;
    T[] _data = new T[DEFAULT_SIZE];

    // 실제로 사용중인 데이터 개수
    public int Count = 0;
    // 예약된 데이터 개수 = 배열의 크기
    public int Capacity { get { return _data.Length; } }
    
    //O(N)이지만, Count가 Capacity보다 클 경우가 드물기 때문에, O(1)로 취급한다. (특이한경우)
    public void Add(T item) {
        // 공간이 남아있지 않으면
        if(Count >= Capacity) {
            // 공간 확보하기 -> 새 배열 만들기
            T[] newArr = new T[Count * 2];
            for(int i=0; i<Count; i++) {
                // 새 배열에 데이터 옮기기
                newArr[i] = _data[i];
            }
            // _data배열을 newArr 배열로 만들기
            _data = newArr;
        }
        // 공간에 데이터 삽입
        _data[Count] = item;
        Count++;
    }
    // 인덱서 문법
    public T this[int index] {
        get {
            return _data[index];
        }
        set {
            _data[index] = value;
        }
    }
    // 삭제 함수
    public void RemoveAt(int index) {
        for(int i=index; i<Count; i++){
            //삭제 element 뒤의 element를 한칸씩 앞으로 당긴다.
            _data[i] = _data[i+1];
        }
        //맨 뒤 요소는 쓰레기이기 때문에 0 또는 NULL 값으로 대체함. 
        _data[Count-1] = default(T);\
        Count--;
    }
}

class Board {

    // 베열
    public int[] _data = new int[25];
    // 동적 배열
    public MyList <int> _data2 = new MyList<int>();
    // 연결 리스트
    public LinkedList <int> _data3 = new LinkedList<int>();

    public void init() {
        _data2.Add(101);
        _data2.Add(102);
        _data2.Add(103);
        _data2.Add(104);
        _data2.Add(105);

        int tmp = _data2[2];
        // 'index==2'인 데이터 삭제
        _data2.RemoveAt(2);
    }
}

