using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{   
    [SerializeField] float moveSpeed = 5f;
    Vector2 rawInput;
    
    //Viewport Space = biểu diễn vị trí theo góc nhìn của camera
    //Để giới hạn người chơi trong phạm vi (boundraries) nhìn thấy của camera, ta sử dụng method ViewportToWorldPoint();
    //ViewportToWorldPoint(): chuyển vị trí chuẩn hóa trên màn hình thành vị trí 3D trong World Space
    //                     => sử dụng để xác định vị trí tương đối của player so với rìa (boundraries) màn hình
    //*Khi thực hiện trong code, chú ý tới góc dưới bên trái và góc trên bên phải do 2 điểm này định hình toàn bộ Viewport

    Vector2 minBounds; //lưu vector2 của điểm (0,0) ở góc dưới bên trái viewport
    Vector2 maxBounds;

    //padding = lề xung quanh rìa màn hình => tránh việc player bị hiển thị mất 1 nửa khi chạm rìa màn hình (do ví trị player
    //                                        được theo dõi qua pivot point(trọng tâm) ).
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;

    Shooter shooter;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }

    void Start()
    {
        InitBounds();
    }

    void Update()
    {
        Move();
    }

    void InitBounds() //init = initialization (khởi tạo)
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = rawInput * moveSpeed * Time.deltaTime;
        Vector2 newPos = new Vector2();
        newPos.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        //Clamp() sẽ chặn các giá trị ngoài phạm vi min và max => Kiểm tra transform.position.x(vị trí hiện tại của player)
        //                                                        + delta.x(khoảng cách mà player sẽ di chuyển)
        //                                                        xem có nằm giữa minBounds.x và maxBounds.x không.
        //                                                        Tương tự với vị trí y
        newPos.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPos;
    }
    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
    }

    void OnFire(InputValue value)
    {
        if(shooter != null)
        {
            shooter.isFiring = value.isPressed;
        }
    }
}
