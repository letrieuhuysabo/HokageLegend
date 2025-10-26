using UnityEngine;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public static class SaveAndLoadSystem
{
    public static void ClearData()
    {
        string path = Path.Combine("Datas");
        // Kiểm tra xem thư mục có tồn tại không
        if (Directory.Exists(path))
        {
            // Xóa tất cả các tệp và thư mục trong thư mục persistentDataPath
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                file.Delete();  // Xóa tệp
            }

            foreach (DirectoryInfo dir in dirInfo.GetDirectories())
            {
                dir.Delete(true);  // Xóa thư mục và nội dung bên trong
            }

            Debug.Log("All data cleared from persistentDataPath.");
        }
        else
        {
            Debug.LogWarning("Directory does not exist.");
        }
    }
    // đường dẫn nhân vật
    public static void SaveCharacterPath(CharacterPath cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterPath.json");
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
    }
    public static CharacterPath LoadCharacterPath()
    {
        string path = Path.Combine("Datas/CharacterPath.json");
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterPath data = JsonUtility.FromJson<CharacterPath>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    // thông tin cơ bản
    public static void SaveCharacterProperties(CharacterProperties cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterProperties.json");
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
    }
    public static CharacterProperties LoadCharacterProperties()
    {
        string path = Path.Combine("Datas/CharacterProperties.json");
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterProperties data = JsonUtility.FromJson<CharacterProperties>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    // vị trí nhân vạt
    public static void SaveCharacterLocation(CharacterLocation cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterLocation.json");
        
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        
    }
    public static CharacterLocation LoadCharacterLocation()
    {
        string path = Path.Combine("Datas/CharacterLocation.json");
        
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterLocation data = JsonUtility.FromJson<CharacterLocation>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    // chỉ số gốc nhân vật
    public static void SaveCharacterBaseAttributes(CharacterBaseAttributes cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterBaseAttributes.json");
        
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        
    }
    public static CharacterBaseAttributes LoadCharacterBaseAttributes()
    {
        // return null;
        string path = Path.Combine("Datas/CharacterBaseAttributes.json");
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterBaseAttributes data = JsonUtility.FromJson<CharacterBaseAttributes>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    // máu và mp hiện tại
    public static void SaveCharacterCurrentAttributes(CharacterCurrentAttributes cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterCurrentAttributes.json");
        
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        
    }
    public static CharacterCurrentAttributes LoadCharacterCurrentAttributes()
    {
        // return null;
        string path = Path.Combine("Datas/CharacterCurrentAttributes.json");
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterCurrentAttributes data = JsonUtility.FromJson<CharacterCurrentAttributes>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
    // phím tắt skill
    public static void SaveCharacterSkillHotKeys(CharacterSkillHotKeys cp)
    {
        // Chuyển đổi đối tượng GameData thành chuỗi JSON
        string json = JsonUtility.ToJson(cp);

        // Xác định đường dẫn lưu trữ (thư mục persistent data)
        string path = Path.Combine("Datas/CharacterSkillHotKeys.json");
        
        // Lưu chuỗi JSON vào file
        File.WriteAllText(path, json);
        
    }
    public static CharacterSkillHotKeys LoadCharacterSkillHotKeys()
    {
        // return null;
        string path = Path.Combine("Datas/CharacterSkillHotKeys.json");
        // Kiểm tra nếu file tồn tại
        if (File.Exists(path))
        {
            // Đọc chuỗi JSON từ file
            string json = File.ReadAllText(path);

            // Chuyển chuỗi JSON thành đối tượng GameData
            CharacterSkillHotKeys data = JsonUtility.FromJson<CharacterSkillHotKeys>(json);
            return data;
        }

        Debug.LogWarning("No data file found.");
        return null;
    }
}
