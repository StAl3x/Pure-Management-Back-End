﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain;

public class DeleteProductFromWarehouseModel
{
    public bool deleteFromProductTable { get; set; }
    public int productId { get; set; }
}
