namespace UnityTools.SaveSystem.Demo
{
    public class SaveFileDemo
    {
        public void CreateSaveFile()
        {
            SaveFile saveFile = new("saveFile", new[]{"Saves"}){
                Cache ={
                    ["test"] = new SaveFile.Data{
                        Key = "test",
                        Value = 5,
                        Type = SaveFile.DataTypes.Int
                    }
                }
            };

            SaveFile.Data data = saveFile["test"];
            data.Value = 10;
            
            saveFile["test"].Value = 15;
            
            saveFile.WriteToFile();
        }
    }
}