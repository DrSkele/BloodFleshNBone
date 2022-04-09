using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserRepository : DataContainer<User>
{
    public UserRepository(DataTransponder data) : base(data) { }
}
