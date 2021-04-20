using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoxelLibrary
{
  
    public class Voxel
    {
        private int voxelX;
        private int voxelY;
        private int voxelZ;

        public Voxel()
        {
        }

        public Voxel(int voxelX, int voxelY, int voxelZ)
        {
            this.voxelX = voxelX;
            this.voxelY = voxelY;
            this.voxelZ = voxelZ;
        }
        public int getVoxelX()
        { return voxelX; }
        public int getVoxelY()
        { return voxelY; }
        public int getVoxelZ()
        { return voxelZ; }

        public void setVoxelX(int value)
        { voxelX= value; }
        public void setVoxelY(int value)
        { voxelY= value; }
        public void setVoxelZ(int value)
        { voxelZ= value; }

    }
}
