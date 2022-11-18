using System.Collections.Generic;
using System.Linq;

namespace Features.Camera.Repository
{
    public class MemoryModelRepository : IModelContext, IModelRepository
    {
        private readonly Dictionary<string, CameraModel> _camerasModel = new Dictionary<string, CameraModel>();

        public void Save(CameraModel model)
        {
            _camerasModel.Add(_camerasModel.Count.ToString(), model);
        }

        public CameraModel FindFirst()
        {
            if (_camerasModel.Count == 0) return null;
            return _camerasModel.First().Value;
        }
    }
}