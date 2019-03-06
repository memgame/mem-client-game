using Colyseus;

namespace MemClientGame.Assets.Scripts.Network.Listeners
{
    public interface IRoomListener
    {
        void OnChange(DataChange obj);   
    }
}