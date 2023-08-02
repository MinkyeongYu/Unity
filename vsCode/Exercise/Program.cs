// DFS
#region 
class Graph {
    int[,] adj = new int[6,6] {
        // 방향이 있는 그래프가 아니기 때문에, 대각선 기준으로 대칭인 형태를 띈다.
        {0,1,0,1,0,0}, 
        {1,0,1,1,0,0}, 
        {0,1,0,0,0,0}, 
        {1,1,0,0,1,0}, 
        {0,0,0,1,0,1}, 
        {0,0,0,0,1,0}
    };

    List<int>[] adj2 = new List<int>[] {
        // list 6개를 가진 배열.
        // 각 리스트는 노드와 같고, 연결된 노드의 인덱스번호를 갖고있다. (ex)0 -> 1,3번과 연결)
        new List<int>() {1,3},  
        new List<int>() {0,2,3},  
        new List<int>() {1},  
        new List<int>() {0,1,4},  
        new List<int>() {3,5},  
        new List<int>() {4},  
    };
    // 연결이 끊긴 그래프 (1,2,3) (4,5)
    int[,] adj3 = new int[6,6] {
        // 방향이 있는 그래프가 아니기 때문에, 대각선 기준으로 대칭인 형태를 띈다.
        {0,1,0,1,0,0}, 
        {1,0,1,1,0,0}, 
        {0,1,0,0,0,0}, 
        {1,1,0,0,0,0}, 
        {0,0,0,0,0,1}, 
        {0,0,0,0,1,0}
    };
    // 2차원 배열로 표현한 그래프 깊이 우선 탐색
    bool[] visited = new bool[6];
    public void DFS (int now) {
        // 1) now부터 방문 후 clear,
        // 2) now와 연결된 정점들을 하나씩 확인해서 미방문 상태라면 방문한다.
        System.Console.WriteLine(now);
        visited[now] = true;
        // adj 방식 - 2차원 배열로 그래프 표현 방식
        for(int next = 0; next < adj.GetLength(0); next++) {
            // 현재 노드와 다음 노드가 연결되지 않은 상태라면 skip
            if(adj[now, next] == 0) continue;
            // 방문했던 노드라면 skip
            if(visited[next]) continue;
            // 재귀함수를 이용해, 연결된 노드를 발견하면 해당 노드를 visited true로 하고, 그 노드와 연결된 것이 있는지 다시 확인
            DFS(next);
        }
    }
    // 리스트로 표현한 그래프 깊이 우선 탐색
    bool[] visited2 = new bool[6];
    public void DFS2 (int now) {
        System.Console.WriteLine((now));
        visited2[now] = true;
        // 리스트 크기가 제각각이기 때문에 visited2에 인덱스가 아니라, 값을 넘겨야해서 foreach 사용.
        foreach(int next in adj2[now]) {
            if(visited2[next]) continue;
            DFS2(next);
        }
    }
    // 연결 끊긴 2차원배열 그래프 깊이 우선 탐색
    bool[] visited3 = new bool[6];
    public void DFS3 (int now) {
        // 1) now부터 방문 후 clear,
        // 2) now와 연결된 정점들을 하나씩 확인해서 미방문 상태라면 방문한다.
        System.Console.WriteLine(now);
        visited3[now] = true;
        // adj 방식 - 2차원 배열로 그래프 표현 방식
        for(int next = 0; next < adj3.GetLength(0); next++) {
            // 현재 노드와 다음 노드가 연결되지 않은 상태라면 skip
            if(adj[now, next] == 0) continue;
            // 방문했던 노드라면 skip
            if(visited3[next]) continue;
            // 재귀함수를 이용해, 연결된 노드를 발견하면 해당 노드를 visited true로 하고, 그 노드와 연결된 것이 있는지 다시 확인
            DFS3(next);
        }
    }
    // DFS를 이용한 끊긴 그래프 모두 탐색하는 함수.
    public void SearchAll() {
        visited3 = new bool[6];
        for(int now = 0; now < 6; now++) {
            if(visited3[now] == false) DFS3(now);
        }
    }
}

class Program {
    static void Main(string[] args) {       
        // DFS : 깊이 우선 탐색 (Depth First Search)
        // BFS : 너비 우선 탐색 (Breadth First Search)
        Graph graph = new Graph();
        graph.DFS(3); 
        // graph.DFS2(3);
        // graph.SearchAll();
    }
}
#endregion


// BFS -> 최단거리, 길찾기 문제에서 출제됨.
class Graph2 {
    int[,] adj = new int[6,6] {
        // 방향이 있는 그래프가 아니기 때문에, 대각선 기준으로 대칭인 형태를 띈다.
        {0,1,0,1,0,0}, 
        {1,0,1,1,0,0}, 
        {0,1,0,0,0,0}, 
        {1,1,0,0,1,0}, 
        {0,0,0,1,0,1}, 
        {0,0,0,0,1,0}
    };

    List<int>[] adj2 = new List<int>[] {
        // list 6개를 가진 배열.
        // 각 리스트는 노드와 같고, 연결된 노드의 인덱스번호를 갖고있다. (ex)0 -> 1,3번과 연결)
        new List<int>() {1,3},  
        new List<int>() {0,2,3},  
        new List<int>() {1},  
        new List<int>() {0,1,4},  
        new List<int>() {3,5},  
        new List<int>() {4},  
    };

    public void BFS(int start) {
        bool[] found = new bool[6];
        Queue<int> q = new Queue<int>();
        q.Enqueue(start);
        found[start] = true;

        // 부모 찾기 위함
        int[] parent = new int[6];
        // 부모와의 거리 구하기 휘함
        int[] distance = new int[6];
        parent[start] = start;
        distance[start] = 0;

        while(q.Count>0) {
            int now = q.Dequeue();
            Console.WriteLine(now);
            for(int next = 0; next <6; next++) {
                if(adj[now, next] == 0) continue;
                if(found[next]) continue;
                // 연결된 노드 모두 큐에 삽입.
                q.Enqueue(next);
                found[next] = true;
                parent[next] = now;
                distance[next] = distance[now] + 1;
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            Graph2 graph = new Graph2();
            graph.BFS(0);
        }
    }
}
