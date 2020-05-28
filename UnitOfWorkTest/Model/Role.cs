using System;

namespace UnitOfWorkTest
{
  public class Role
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public bool Valid { get; set; }

    public Role(string name)
    {
      Id = Guid.NewGuid().ToString();
      Name = name;
      Valid = true;
    }
  }
}
