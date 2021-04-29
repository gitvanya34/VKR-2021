using System;
using System.Collections.Generic;
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
        private MeshVoxel[,,] allMeshVoxels;//все воксели в сетке включая те которые не участвуют в проприсовке(Пустые воксели)
        private VoxelLibrary.Voxel[] voxels;//на выходе здесь должны лежать воксели по порядку изготовления (Зависит от типа сканироваиня, использовать будем змейку)

        /*пробуем сделать трехмерной массив всего пространства печати, 
        а затем отделить воксели которые должны печаться и которые остаются пустые
        в данный момент нужно решить вопрос о том на каком уровне будет строиться сетка расчетов*/

       

        /*На вход контруктор получает полный массив вокселей которые в будущем отсортируются по порядку прорисовки
        (или как вариант устроить проверку в самой сетке, есть ли желаемый для прорисовки воксель, если есть то отрисовать/расчтитать напругу)*/
        public ScanningModel(Voxel[] voxels)
        {
            this.voxels = voxels;

            Meshing();
        }


        public MeshVoxel[,,] getAllMeshVoxels()
        { return allMeshVoxels; }

        public int getMaxX()
        { return maxX; }

        public int getMaxY()
        { return maxY; }

        public int getMaxZ()
        { return maxZ; }

        public int getMinX()
        { return minY; }
        public int getMinY()
        { return minY; }
        public int getMinZ()
        { return minZ; }
       

        /*Построение сетки*/
        public void Meshing()
        {
            FindMeshBorder();
            //заполнение сетки
            //int number_of_voxels_in_mesh = maxX * maxY * maxZ;
            allMeshVoxels = new MeshVoxel[maxX + 1, maxY + 1, maxZ + 1];
            for (int z = minZ; z <= maxZ; z++)
            {
                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = minY; y <= maxY; y++)
                    {
                        allMeshVoxels[x, y, z] = new MeshVoxel(x, y, z);
                    }
                }
            }

            CheckVoxelInModel();
        }

        /*TODO Найти максмумы и минимумы пространства вызов должен быть из visuallibrary*/
        /*Находим границы сетки из объекта класса используется внутри класса*/
        public void FindMeshBorder()
        {
            minX = 0; maxX = 0; minY = 0; maxY = 0; minZ = 0; maxZ = 0;

            foreach (Voxel voxel in voxels)
            {
                minX = voxel.getVoxelX() < minX ? voxel.getVoxelX() : minX;
                minY = voxel.getVoxelY() < minY ? voxel.getVoxelY() : minY;
                minZ = voxel.getVoxelZ() < minZ ? voxel.getVoxelZ() : minZ;

                maxX = voxel.getVoxelX() > maxX ? voxel.getVoxelX() : maxX;
                maxY = voxel.getVoxelY() > maxY ? voxel.getVoxelY() : maxY;
                maxZ = voxel.getVoxelZ() > maxZ ? voxel.getVoxelZ() : maxZ;

            }
            Console.WriteLine("%d %d ", maxX, minX);
            Console.WriteLine("%d %d ", maxY, minY);
            Console.WriteLine("%d %d ", maxZ, minZ);

        }

        //проверка какие воксели являются частью модели, установка буллов для мешВоксель
        public void CheckVoxelInModel()
        {
            foreach(Voxel voxel in voxels)
            {
                allMeshVoxels[voxel.getVoxelX(),
                              voxel.getVoxelY(),
                              voxel.getVoxelZ()].setBoolScanned(true);
            }    
        }

        //сканирование змейкой метод для моделирования псолойного изготовления (можно потом сделать еще методом шазматной доски)
        //должен вернуть список или (одномерный массив с вокселями по порядку сканирования для того что бы в будущем из перебрать )
        public int [][]  SnakeScanning()
        {
            //for (int z = minZ; z <= maxZ; z++)
            //{
            //    for (int x = minX; x <= maxX; x++)
            //    {
            //        for (int y = minY; y <= maxY; y++)
            //        {
            //            allMeshVoxels[x, y, z] = new MeshVoxel(x, y, z);
            //        }
            //    }
            //}

            //добавить проверку должен ли воксель печататься 
            List<int[]> listSnake = new List<int[]>();
            for (int z = minZ; z < maxZ; z++)
            {
                for (int y = minY; y < maxY; y++)
                {
                    if (y % 2 == 0)
                        for (int x = minX; x < maxX; x++)
                        {
                            listSnake.Add(new int[3] { x, y, z });
                        }
                    if (y % 2 != 0)
                        for (int x = maxX-1; x >= minY; x--)
                        {
                            listSnake.Add(new int[3] { x, y, z });
                        }
                }
            }
            
            return  listSnake.ToArray();
        }
    }
}
