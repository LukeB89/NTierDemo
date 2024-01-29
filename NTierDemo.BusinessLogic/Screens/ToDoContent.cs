using NTierDemo.BusinessLogic.DTOs.Controls;
using NTierDemo.BusinessLogic.DTOs.Structs;

namespace NTierDemo.BusinessLogic;
public abstract class ToDoContentBase
{
    public List<object> GetToDoCardData()
    {
        // ToDo This will be actual Data from the database
        List<object> root = new()
        {
            new ToDoCardData("Clean Kitchen", "#00FFFFFF", "C_Pallet1", new ThicknessData(2), new CornerRadiusData(10), new ThicknessData(5)),
            new ToDoCardData("Tidy Bedroom", "#00FFFFFF", "C_Pallet2", new ThicknessData(2), new CornerRadiusData(10), new ThicknessData(5)),
            new ToDoCardData("Data Access Layer", "#00FFFFFF", "C_Pallet3", new ThicknessData(2), new CornerRadiusData(10), new ThicknessData(5)),
            new ToDoCardData("Remove Dummy Data", "#00FFFFFF", "C_Pallet4", new ThicknessData(2), new CornerRadiusData(10), new ThicknessData(5)),
            new ToDoCardData("Demonstrate", "#00FFFFFF", "C_Pallet5", new ThicknessData(2), new CornerRadiusData(10), new ThicknessData(5))
        };

        return root;
    }
}