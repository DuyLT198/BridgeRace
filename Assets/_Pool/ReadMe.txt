Simple dùng để quản lý các prefab pooling tối ưu cho game

Ý tưởng xây dựng là một trong nhưng design pattern không thể thiếu trong việc tối ưu game
pool là kho chưa các object để có thể sử dụng lại mỗi khi cần

Ưu điểm: 
+ dễ sử dụng
+ tối ưu hơn về hiệu năng
+ có thể sử dụng trong hầu hết project cả project lớn
+ dùng khá tương đồng instantiate

SimplePool : pool cho các object in game

 Yêu cầu: 
 + object muốn dùng simple pool phải kế thừa GameUnit, chọn PoolType tương ứng
 + mỗi member cần một PoolType riêng, nếu k dùng đến Pool nhưng vẫn kế thừa thì có thể để PoolType là None

 Hàm có thể sử dụng:
 + SimplePool.Spawn(<Pool Member>, Vector3 vitri, Quaternion gocxoay) : gọi pool member ra để sử dụng
 + SimplePool.Spawn<Script Name>(PoolType, vector3 vitri, Quaternion gocxoay) : gọi pool member ra để sử dụng bằng PoolType và ép kiểu 
 + SimplePool.Spawn<Script Name>(PoolType, Transform parent) : gọi pool member ra để sử dụng và set vị trí nó là con của parent bằng PoolType và ép kiểu sang script tương ứng -> xem thêm 1 số kiểu trong code
 + SimplePool.Despawn(PoolMember) : cất object đó và pool
 + SimplePool.Collect(PoolType) : cất tất cả object là pooltype đó vào pool
 + SimplePool.CollectAll : cất tất cả object pool vào pool -> thường dùng khi kết thúc game và chuyển màn
 + SimplePool.Release(PoolType) : destroy tất cả object là pooltype đó -> thường dùng với một số game lớn để tối ưu 

ParticlePool : pool dùng cho particle <hiệu ứng>

 Yêu cầu: 
 + object muốn dùng sẽ phải là 1 particle system
 + cần có 1 object add script PoolControler để kiểm soát, add particle đó vào list particle
 + mỗi member đó sẽ cần thêm 1 ParticleType

 Hàm có thể sử dụng:
 + Particle.Play(ParticleType, Vector3 vitri, Quaternion gocxoay) : gọi particle ra để dùng
 + Particle.Release(ParticleType) : destroy toàn bộ particle đó

MiniPool : pool chỉ pool cho một loại object, thường dùng trong trường hợp bạn chỉ muốn pool đó nằm gọn trong 1 object cha, ví dụ như pool item trong inventory, pool các điểm chấm chấm khi kéo trong game angry bird..., pool UI đồng tiền bay lên
 Yêu cầu:  
 + Cần khởi tạo MiniPool<ScriptName> miniPool = new MiniPool<ScriptName>();
 + khởi tạo trong Awake hoặc Start miniPool.OnInit(<Object>, <số lượng>, <Transform cha>)
 Hàm có thể sử dụng:
 + miniPool.Spawn : lấy ra khỏi mini pool để dùng
 + miniPool.Despawn : cất vào
 + miniPool.Collect : thu tất cả vào mini pool
 + miniPool.Release : destroy tất cả




