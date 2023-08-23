#region 
class Graph {
    int[,] adj = new int[6,6] {
        // 연결된 표시를 0,1이 아니라, 가중치로 입력. 끊어진 것은 -1로 표시
        {-1, 15, -1, 35, -1, -1}, 
        {15, -1, 5, 10, -1, -1}, 
        {-1, 5, -1, -1, -1, -1}, 
        {35, 10, -1, -1, 5, -1}, 
        {-1, -1, -1, 5, -1, 5}, 
        {-1, -1, -1, -1, 5, -1}
    };

    //다익스트라
    public async void Dijkstra(int start) {
        bool[] visited = new bool[6];
        int[] parent = new int[6];
        // 가중치 비교
        int[] distance = new int[6];
        // 가중치 배열의 모든 값을 int32로 표현할 수 있는 가장 큰 값으로 채운다.
        Array.Fill(distance, Int32.MaxValue);
        distance[start] = 0;
        parent[start] = start;

        while(true) {
            // 가장 유력한 후보의 가중치, 번호 저장
            int closest = Int32.MaxValue;
            int now = -1;
            // 제일 좋은 후보 찾기
            for(int i = 0; i<6; i++) {
                if(visited[i]) continue;
                if(distance[i] == Int32.MaxValue || distance[i] >= closest) continue;
                // 여태까지 발견한 가장 좋은 후보
                closest = distance[i];
                now = i;
            }
            // 다음 후보가 없으면 종료
            if(now == -1) break;
            // 제일 좋은 후보를 발견햇으니까 방문.
            visited[now] = true;
            for(int next = 0; next<6; next++) {
                // 연결 확인
                if(adj[now, next] == -1) continue;
                if(visited[next]) continue;
                // 새로 조사된 정점의 최단거리를 계산한다.
                int nextDistance = distance[now] + distance[now, next];
                
                if(nextDistance < distance[next]) {
                    distance[next] = nextDistance;
                    parent[next] = now;
                }
            }
        }
    }
}

class Program {
    static void Main(string[] args) {       
        
    }
}
#endregion