class MyList<T>
{
    const int DEFAULT_SIZE = 1;
    T[] _data = new T[DEFAULT_SIZE];

    // 실제로 사용중인 데이터 개수
    public int Count = 0;
    // 예약된 데이터 개수 = 배열의 크기
    public int Capacity { get { return _data.Length; } }

    //O(N)이지만, Count가 Capacity보다 클 경우가 드물기 때문에, O(1)로 취급한다. (특이한경우)
    public void Add(T item)
    {
        // 공간이 남아있지 않으면
        if (Count >= Capacity)
        {
            // 공간 확보하기 -> 새 배열 만들기
            T[] newArr = new T[Count * 2];
            for (int i = 0; i < Count; i++)
            {
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
    public T this[int index]
    {
        get
        {
            return _data[index];
        }
        set
        {
            _data[index] = value;
        }
    }
    // 삭제 함수
    public void RemoveAt(int index)
    {
        for (int i = index; i < Count; i++)
        {
            //삭제 element 뒤의 element를 한칸씩 앞으로 당긴다.
            _data[i] = _data[i + 1];
        }
        //맨 뒤 요소는 쓰레기이기 때문에 0 또는 NULL 값으로 대체함. 
        _data[Count - 1] = default(T);
        Count--;
    }
}

// 양방향 연결리스트 
class MyLinkedListNode<T>
{
    public T Data;
    public MyLinkedListNode<T> Next;
    public MyLinkedListNode<T> Prev;
}
class MyLinkedList<T>
{
    // 첫번째 방
    public MyLinkedListNode<T> Head = null;
    // 마지막 방
    public MyLinkedListNode<T> Tail = null;
    public int Count = 0;

    //O(1)
    public MyLinkedListNode<T> AddLast(T data)
    {
        MyLinkedListNode<T> newRoom = new MyLinkedListNode<T>();
        newRoom.Data = data;
        // 만약에 방이 없다면, 새로 추가한 첫번째 방이 곧 Head
        if (Head == null)
        {
            Head = newRoom;
        }
        // 기존의 Tail과 새로 추가되는 방을 연결해준다.
        if (Tail != null)
        {
            Tail.Next = newRoom;
            newRoom.Prev = Tail;
        }

        Tail = newRoom;
        Count++;

        return newRoom;
    }
    //O(1)
    // 방 삭제 (Next, Prev 노드를 새로 이어준다)
    public void Remove(MyLinkedListNode<T> room)
    {
        // 삭제할 방이 맨 첫번째 방이라면, 그 다음방을 Head로 설정.
        if (Head == room)
        {
            Head = Head.Next;
        }
        // 삭제할 방이 맨 마지막 방이라면, 그 앞의 방을 Tail로 설정. 
        if (Tail == room)
        {
            Tail = Tail.Prev;
        }
        // 일반적인 삭제 -> 삭제할 방의 이전 방이 null이 아니라면, 삭제할 방의 이전방의 다음방이 삭제할 방의 다음방과 연결되게 설정.
        if (room.Prev != null)
        {
            room.Prev.Next = room.Next;
        }
        // 위와 동일한 방식으로, 삭제할 방의 이전방과 삭제할 방의 다음방 연결.
        if (room.Next != null)
        {
            room.Next.Prev = room.Prev;
        }
        Count--;
    }
}

class Board
{

    // 베열
    public int[] _data = new int[25];
    // 동적 배열
    // public MyList <int> _data2 = new MyList<int>();
    // 연결 리스트
    public MyLinkedList<int> _data3 = new MyLinkedList<int>();

    public void init()
    {
        // _data2.Add(101);
        // _data2.Add(102);
        // _data2.Add(103);
        // _data2.Add(104);
        // _data2.Add(105);

        // int tmp = _data2[2];
        // 'index==2'인 데이터 삭제
        // _data2.RemoveAt(2);
        _data3.AddLast(101);
        _data3.AddLast(102);
        MyLinkedListNode<int> node = _data3.AddLast(103);
        _data3.AddLast(104);
        _data3.AddLast(105);

        // 103에 해당하는 요소 제거
        _data3.Remove(node);

    }
}

