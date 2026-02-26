using System;
using Core.Entities;

namespace Core.Specifications;

public class TypeListSpecification : BaseSpecification<Post, string>
{
    public TypeListSpecification()
    {
        AddSelect(p => p.Type);
        ApplyDistinct();
    }

}
