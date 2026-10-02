# Problem Solving & Data Organization - C#

## Thông tin sinh viên
- Họ tên: Nguyễn Việt Anh
- Mã số học viên: 11410123065
- Lớp: K26ISTG01

## Công nghệ
- C# / .NET 8
- xUnit
- Visual Studio 2022 hoặc VS Code

## Nội dung
### Phần 1 - 5 bài bắt buộc
1. Tìm số nguyên tố thứ N.
2. Đảo chuỗi không dùng hàm Reverse có sẵn.
3. Kiểm tra palindrome, bỏ qua khoảng trắng/dấu câu.
4. Tìm phần tử lớn thứ K bằng min-heap.
5. Đếm tần suất ký tự bằng Dictionary.

### Phần 2 - 3 bài đã chọn
1. Quản lý danh bạ: Dictionary.
2. LRU Cache: Dictionary + LinkedList.
3. Priority Queue lập lịch task: binary heap qua PriorityQueue của .NET.

### Phần 3
Tìm đường ngắn nhất trong mê cung bằng BFS và A*, có benchmark thực tế.

## Chạy project
```bash
dotnet restore
dotnet run --project src/ProblemSolving.csproj
```

## Chạy unit test
```bash
dotnet test
```

## Cấu trúc
- `src/Part1`: thuật toán cơ bản
- `src/Part2`: cấu trúc dữ liệu
- `src/Part3`: BFS, A*, benchmark
- `tests`: unit tests

## Độ phức tạp chính
| Bài toán | Cấu trúc/thuật toán | Time | Space |
|---|---|---:|---:|
| Reverse string | Array | O(n) | O(n) |
| Palindrome | Two pointers | O(n) | O(1) |
| Kth largest | Min-heap K phần tử | O(n log k) | O(k) |
| Character count | Hash map | O(n) | O(m) |
| Contact manager | Hash map | TB O(1) CRUD | O(n) |
| LRU Cache | Hash map + linked list | TB O(1) Get/Put | O(capacity) |
| Priority Queue | Heap | O(log n) enqueue/dequeue | O(n) |
| BFS | Queue | O(V+E) | O(V) |
| A* | Priority queue | phụ thuộc heuristic; heap O(log V)/operation | O(V) |

