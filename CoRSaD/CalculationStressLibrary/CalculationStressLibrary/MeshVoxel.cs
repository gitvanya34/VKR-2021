using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VoxelLibrary;

namespace CalculationStressLibrary
{
    public class MeshVoxel//сделтаь наследование от Voxel
    {
        private VoxelLibrary.Voxel voxel;

        private bool boolScanned; //отсканированны воксели True если воксель должен печаться, по умолчанию FAlse
        private bool boolScannedCount;// true Вкосели которые отсканированные на данный момент расчета

        public Voxel Voxel { get => voxel; set => voxel = value; }

        public MeshVoxel(int x,int y, int z/*, bool boolScanned*/)
        {
            voxel = new VoxelLibrary.Voxel(x, y, z);
            boolScanned = false;
            boolScannedCount = false;
          //  this.boolScanned = boolScanned;
        }
        public void setBoolScanned(bool boolScanned)
        {
            this.boolScanned = boolScanned;
        }
        public bool getBoolScanned()
        { return boolScanned; }


        //гетеры должны убраться если унаследовать с полиморфизмом перегрузить
        public int getVoxelX()
        { return voxel.getVoxelX(); }
        public int getVoxelY()
        { return voxel.getVoxelY(); }
        public int getVoxelZ()
        { return voxel.getVoxelZ(); }
  
    }
}
