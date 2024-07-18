using UnityEngine;
using UnityEngine.UI;
using SFB;

public class ApiController : MonoBehaviour
{
    public string apiUrl;
    public InputField pathInputField;

    private void Start()
    {
        ApiManager.Instance.Get(apiUrl, OnDataReceived);
    }

    private void OnDataReceived(string jsonResponse)
    {
        if (string.IsNullOrEmpty(jsonResponse))
        {
            Debug.LogError("Failed to get data from API");
            return;
        }

        try
        {
            ApiResponse response = JsonUtility.FromJson<ApiResponse>(jsonResponse);
            if (response != null && response.data != null)
            {
                foreach (Datum card in response.data)
                {
                    if (card.card_images != null && card.card_images.Count > 0)
                    {
                        // Lấy ID và URL ảnh đầu tiên của mỗi thẻ
                        int cardId = card.id;
                        string imageUrl = card.card_images[0].image_url;
                        Debug.Log($"Card ID: {cardId}, Image URL: {imageUrl}");
                    }
                }
            }
            else
            {
                Debug.LogError("Failed to parse API response");
            }
        }
        catch (System.Exception ex)
        {
            Debug.LogError("Exception caught while parsing API response: " + ex.Message);
        }
    }

    public void OnBrowseButtonClick()
    {
        // Mở trình duyệt tệp
        var paths = StandaloneFileBrowser.OpenFilePanel("Select File", "", "", false);

        // Kiểm tra nếu người dùng đã chọn tệp
        if (paths.Length > 0)
        {
            string selectedPath = paths[0];
            pathInputField.text = selectedPath; // Đưa đường dẫn vào InputField
        }
    }
}
