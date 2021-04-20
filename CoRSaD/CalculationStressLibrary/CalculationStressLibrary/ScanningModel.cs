using System;
using VoxelLibrary;
namespace CalculationStressLibrary
{
    public class ScanningModel
    {
        //задаем границы воксслеьной модели забивтаь будем в контруктор 
        private int minX;
        private int maxX;

        private int minY;
        private int maxY;

        private int minZ;
        private int maxZ;

        private VoxelLibrary.Voxel [] voxels;//на выходе здесь должны лежать воксели по порядку изготовления (Зависит от типа сканироваиня, использовать будем змейку)

        /*пробуем сделать трехмерной массив всего пространства печати, 
        а затем отделить воксели которые должны печаться и которые остаются пустые
        в данный момент нужно решить вопрос о том на каком уровне будет строиться сетка расчетов*/

        private bool boolScanned; //отсканированны воксели True если воксель должен печаться, по умолчанию FAlse
        private bool boolScannedCount;// true Вкосели которые отсканированные на данный момент расчета

        public ScanningModel( Voxel[] voxels)
        {      
            this.voxels = voxels;
        }
        /*TODO Найти максмумы и минимумы пространства вызов должен быть из visuallibrary*/
    }
}
