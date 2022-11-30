using System.ComponentModel.DataAnnotations;

public class RoomType{
    public int Id { get; set; }

    public roomType? Type {get; set;}

    public Price? Price {get; set;}
} 

public enum roomType{
    Deluxe,
    Suite,
    Double,
    Single
}