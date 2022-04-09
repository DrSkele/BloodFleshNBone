using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitOfWork 
{
    DataTransponder data;

    UserRepository users;

    public void Save()
    {
        data.Save();
    }
}
