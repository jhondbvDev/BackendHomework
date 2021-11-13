using BackendHomework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackendHomework.Core.Interfaces
{
    public interface IIngredientService
    {
        IEnumerable<Ingredient> GetIngredients();
        IEnumerable<Ingredient> GetIngredientByPlateId(int plateId);

    }
}
