using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaLeenkenGroupEntities context = new DL.FMolinaLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetAll().ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = obj.IdEmpleado;
                            empleado.NumeroNomina = obj.NumeroNomina;
                            empleado.Nombre = obj.Nombre;
                            empleado.ApellidoPaterno = obj.ApellidoPaterno;
                            empleado.ApellidoMaterno = obj.ApellidoMaterno;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = obj.IdEstado;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaLeenkenGroupEntities context = new DL.FMolinaLeenkenGroupEntities())
                {
                    var query = context.EmpleadoAdd(empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoMaterno, empleado.ApellidoMaterno, empleado.Estado.IdEstado);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar";
                    }
                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaLeenkenGroupEntities context = new DL.FMolinaLeenkenGroupEntities())
                {
                    var query = context.EmpleadoUpdate(empleado.IdEmpleado, empleado.NumeroNomina, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.IdEstado);

                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaLeenkenGroupEntities context = new DL.FMolinaLeenkenGroupEntities())
                {
                    var query = context.EmpleadoGetById(IdEmpleado).FirstOrDefault();

                    if (query != null)
                    {
                        ML.Empleado empleado = new ML.Empleado();

                        empleado.IdEmpleado = query.IdEmpleado;
                        empleado.NumeroNomina = query.NumeroNomina;
                        empleado.Nombre = query.Nombre;
                        empleado.ApellidoPaterno = query.ApellidoPaterno;
                        empleado.ApellidoMaterno = query.ApellidoMaterno;
                        empleado.IdEstado = query.IdEstado.Value;

                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Delete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.FMolinaLeenkenGroupEntities context = new DL.FMolinaLeenkenGroupEntities())
                {
                    var query = context.EmpleadoDelete(empleado.IdEmpleado);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
