namespace SelfTask_Dimensions;

class Program
{
    static void Main(string[] args)
    {
        Vector2 vector2 = new Vector2(2, 5);
        
        Vector3 positionA = new Vector3(1, 2, 4);
        
        Vector3 positionB = new Vector3(2, 5, 6);

        for (int i = 0; i < 10; i++)
        {
            positionA += (Vector3.forward + Vector3.up);
        }
        
        positionA.GetPosition();
    }
}