using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExaltGrecian : ObeySubstrate<ExaltGrecian>
{
    public void EvenExalt(string info)
    {
        UIGrecian.AshForecast().EvenUIDaddy(nameof(Exalt), info);
    }
}
