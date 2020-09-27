using Microsoft.AspNetCore.Mvc.ModelBinding;
public class ModelErrorHelper
    {
        /// <summary>
        /// 返回模型验证错误信息
        /// </summary>
        /// <param name="modelState"></param>
        /// <returns></returns>
        public static string ErrorMessage(ModelStateDictionary modelState)
        {
            var error = string.Empty;
            foreach (var item in modelState)
            {
                foreach (var errorItem in item.Value.Errors)
                {
                    error = errorItem.ErrorMessage;
                    break;
                }

                if (!string.IsNullOrWhiteSpace(error))
                    break;
            }

            return error;
        }
    }
