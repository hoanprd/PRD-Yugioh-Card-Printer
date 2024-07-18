using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardImage
{
    public int id;
    public string image_url;
    public string image_url_small;
}

[System.Serializable]
public class Datum
{
    public int id;
    public List<CardImage> card_images;
}

[System.Serializable]
public class ApiResponse
{
    public List<Datum> data;
}
