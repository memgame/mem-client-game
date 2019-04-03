using Colyseus.Schema;

namespace MemClientGame.Assets.Scripts.Network.StateHandlers
{
    public interface IStateHandler<T>
    {
        void OnAdd(object sender, KeyValueEventArgs<T, string> e);
        void OnRemove(object sender, KeyValueEventArgs<T, string> e);
        void OnChange(object sender, KeyValueEventArgs<T, string> e);
    }
}