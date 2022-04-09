using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class DataContainer<T>
{
    DataTransponder transponder;

    public DataContainer(DataTransponder data)
    {
        this.transponder = data;
    }
    public virtual void Create(T entity)
    {
        
    }
    public virtual void Delete(T entity)
    {
        
    }
}
