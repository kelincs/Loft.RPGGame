using Loft.RPGGame.Domain.Enums;

namespace Loft.RPGGame.Domain.Entities
{
    public class Attributes
    {
        public Dictionary<AttributeTypeEnum, short> AttributesDic { get; set; }      

        public Attributes()
        {
            AttributesDic = new();
            var occupationTypeEnumNames = Enum.GetValues<AttributeTypeEnum>().ToList();

            occupationTypeEnumNames.ForEach(attributeType =>
            {
                AttributesDic.Add(attributeType, 0);
                
            });
        }
    }
}