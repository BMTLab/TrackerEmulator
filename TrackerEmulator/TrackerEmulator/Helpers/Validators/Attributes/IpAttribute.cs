// TrackerEmulator IpAttribute.cs
// Created by Nikita Neverov at 30.08.2019 10:30

using System.ComponentModel.DataAnnotations;

namespace TrackerEmulator.Helpers.Validators.Attributes
{
    public class IpAttribute : ValidationAttribute
    {
        //public override bool IsValid(object value)
        //{
        //    if (value == null)
        //        return false;

        //    IP userName = value.ToString();

        //    if (!userName.StartsWith("T"))
        //        return true;
        //    else
        //        this.ErrorMessage = "Имя не должно начинаться с буквы T";
        //    return false;
        //}
    }
}
