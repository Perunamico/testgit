using System.Collections.Generic;
public class DataExample : Data
{
    // ここを実験で取りたいデータに書き換える
    public float Hoge { private get; set; }
    public float Fuga { private get; set; }
    public float Piyo { private set; get; }

    // 上記のデータをValuesとHeaderに反映させる
    public override List<object> Values => new List<object>()
    {
        Hoge,
        Fuga,
        Piyo,
    };
    public override string Header => "ID,Condition,Hoge,Fuga,Piyo";

    /// <summary>
    /// コンストラクタ
    /// </summary>
    /// <param name="id"></param>
    /// <param name="condition"></param>
    /// <param name="hoge"></param>
    /// <param name="fuga"></param>
    /// <param name="piyo"></param>
    public DataExample(int id, int condition, float hoge, float fuga, float piyo) : base(id, condition)
    {
        Hoge = hoge;
        Fuga = fuga;
        Piyo = piyo;
    }
}
