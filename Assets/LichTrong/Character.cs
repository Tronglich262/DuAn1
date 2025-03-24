using UnityEngine;

public abstract class Character
{
    protected int hp { get; set; }
    protected float speed { get; set; }
    protected Rigidbody2D body { get; set; }
    protected Animator animator { get; set; }
    protected BoxCollider2D boxCollider2D { get; set; }
    protected Transform transform { get; set; }
    protected float horizontalInput;

    public Character(GameObject gameObject)
    {
        hp = 10;
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        boxCollider2D = gameObject.GetComponent<BoxCollider2D>();
        transform = gameObject.transform;
    }

    public void Update()
    {
        InputHandle();
        FlipSprite();
    }

    protected abstract void InputHandle();

    private void FlipSprite()
    {

    }
}

public class Jack : Character
{
    public Jack(GameObject gameObject) : base(gameObject)
    {
        speed = 5;
    }

    protected override void InputHandle()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}

public class Ross : Character
{
    public Ross(GameObject gameObject) : base(gameObject)
    {
        speed = 6;
    }

    protected override void InputHandle()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}

public class Tasi : Character
{
    public Tasi(GameObject gameObject) : base(gameObject)
    {
        speed = 7;
    }

    protected override void InputHandle()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}

public class Apollo : Character
{
    public Apollo(GameObject gameObject) : base(gameObject)
    {
        speed = 8;
    }

    protected override void InputHandle()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }
}
