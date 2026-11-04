public interface ISellable
{
  int BuyCost { get; }
  int GetSellValue();
  void OnSell();
}