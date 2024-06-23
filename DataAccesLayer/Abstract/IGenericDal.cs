﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Abstract
{
    public interface IGenericDal<T>
    {
        void Insert(T t);

        void Delete(T t);

        void Update(T t);

       List<T> GetList();
    }
}
