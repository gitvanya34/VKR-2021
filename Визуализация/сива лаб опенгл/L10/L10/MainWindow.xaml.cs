using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace L10
{
    public partial class MainWindow : Window
    {
        GeometryModel3D mGeometry;
        bool mDown;
        Point mLastPos;

        public MainWindow()
        {
            InitializeComponent();

            // Define 3D mesh object
            MeshGeometry3D mesh = new MeshGeometry3D();

           //точки объекта
            //x
            //mesh.Positions.Add(new Point3D(0, 0, 0));         //    0
            //mesh.Positions.Add(new Point3D(0, 0.4, 0));       // 1
            //mesh.Positions.Add(new Point3D(0.25, 1, 0));   //  2   
            //mesh.Positions.Add(new Point3D(0.4, 0.75, 0));    //3

            //mesh.Positions.Add(new Point3D(0.6, 1, 0));   //  4  
            //mesh.Positions.Add(new Point3D(1, 0, 0));      //5
            //mesh.Positions.Add(new Point3D(0.75, 0, 0));  //6
            

            /////-x

            //mesh.Positions.Add(new Point3D(-0.25, 1, 0));   //7  
            //mesh.Positions.Add(new Point3D(-0.4, 0.75, 0)); //8
            //mesh.Positions.Add(new Point3D(-0.6, 1, 0));    //9 
            //mesh.Positions.Add(new Point3D(-1, 0, 0));      //10
            //mesh.Positions.Add(new Point3D(-0.75, 0, 0));   //11

            /////-z 
            //mesh.Positions.Add(new Point3D(0, 0, -0.25));         //12
            //mesh.Positions.Add(new Point3D(0, 0.4, -0.25));       // 13
            //mesh.Positions.Add(new Point3D(0.25, 1, -0.25));     //14  
            //mesh.Positions.Add(new Point3D(0.4, 0.75, -0.25));    //15

            //mesh.Positions.Add(new Point3D(0.6, 1, -0.25));      //16  
            //mesh.Positions.Add(new Point3D(1, 0, -0.25));         //17
            //mesh.Positions.Add(new Point3D(0.75, 0, -0.25));     //18

            //mesh.Positions.Add(new Point3D(-0.25, 1, -0.25));   //19  
            //mesh.Positions.Add(new Point3D(-0.4, 0.75, -0.25)); //20
            //mesh.Positions.Add(new Point3D(-0.6, 1, -0.25));    //21  
            //mesh.Positions.Add(new Point3D(-1, 0, -0.25));      //22
            //mesh.Positions.Add(new Point3D(-0.75, 0, -0.25));   //23
            
            //////////////////////////
            // mesh.Positions.Add(new Point3D(-0.1, 0, 0));         //    24
            //mesh.Positions.Add(new Point3D(0.1, 0, 0));         //    25
            //mesh.Positions.Add(new Point3D(-0.1, 0, -0.25));         //    26
            //mesh.Positions.Add(new Point3D(0.1, 0, -0.25));           //27

            //mesh.TriangleIndices.Add(24);
            //mesh.TriangleIndices.Add(26);
            //mesh.TriangleIndices.Add(25);

            //mesh.TriangleIndices.Add(25);
            //mesh.TriangleIndices.Add(26);
            //mesh.TriangleIndices.Add(27);

            //mesh.TriangleIndices.Add(8);
            //mesh.TriangleIndices.Add(20);
            //mesh.TriangleIndices.Add(24);

            //mesh.TriangleIndices.Add(20);
            //mesh.TriangleIndices.Add(26);
            //mesh.TriangleIndices.Add(24);

            //mesh.TriangleIndices.Add(3);
            //mesh.TriangleIndices.Add(15);
            //mesh.TriangleIndices.Add(25);

            //mesh.TriangleIndices.Add(15);
            //mesh.TriangleIndices.Add(27);
            //mesh.TriangleIndices.Add(25);
            ////создание треугольников
            //////////////x
            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(2);
            //mesh.TriangleIndices.Add(1);
           
            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(3);
            //mesh.TriangleIndices.Add(2);

            //mesh.TriangleIndices.Add(2);
            //mesh.TriangleIndices.Add(5);
            //mesh.TriangleIndices.Add(4);

            //mesh.TriangleIndices.Add(2);
            //mesh.TriangleIndices.Add(6);
            //mesh.TriangleIndices.Add(5);
            ///////////-x
            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(1);
            //mesh.TriangleIndices.Add(7);

            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(7);
            //mesh.TriangleIndices.Add(8);

            //mesh.TriangleIndices.Add(7);
            //mesh.TriangleIndices.Add(9);
            //mesh.TriangleIndices.Add(10);

            //mesh.TriangleIndices.Add(7);
            //mesh.TriangleIndices.Add(10);
            //mesh.TriangleIndices.Add(11);

            /////////-z
            //mesh.TriangleIndices.Add(12);
            //mesh.TriangleIndices.Add(13);
            //mesh.TriangleIndices.Add(14);

            //mesh.TriangleIndices.Add(12);
            //mesh.TriangleIndices.Add(14);
            //mesh.TriangleIndices.Add(15);

            //mesh.TriangleIndices.Add(14);
            //mesh.TriangleIndices.Add(16);
            //mesh.TriangleIndices.Add(17);

            //mesh.TriangleIndices.Add(14);
            //mesh.TriangleIndices.Add(17);
            //mesh.TriangleIndices.Add(18);
            
            //mesh.TriangleIndices.Add(12);
            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(13);

            //mesh.TriangleIndices.Add(12);
            //mesh.TriangleIndices.Add(20);
            //mesh.TriangleIndices.Add(19);

            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(22);
            //mesh.TriangleIndices.Add(21);

            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(23);
            //mesh.TriangleIndices.Add(22);

            /////торец
            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(12);
            //mesh.TriangleIndices.Add(15);

            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(15);
            //mesh.TriangleIndices.Add(3);
            ////
            //mesh.TriangleIndices.Add(3);
            //mesh.TriangleIndices.Add(15);
            //mesh.TriangleIndices.Add(6);

            //mesh.TriangleIndices.Add(6);
            //mesh.TriangleIndices.Add(15);
            //mesh.TriangleIndices.Add(18);
            ////
            //mesh.TriangleIndices.Add(6);
            //mesh.TriangleIndices.Add(18);
            //mesh.TriangleIndices.Add(5);


            //mesh.TriangleIndices.Add(5);
            //mesh.TriangleIndices.Add(18);
            //mesh.TriangleIndices.Add(17);
            ////
            //mesh.TriangleIndices.Add(5);
            //mesh.TriangleIndices.Add(17);
            //mesh.TriangleIndices.Add(16);
            
            //mesh.TriangleIndices.Add(5);
            //mesh.TriangleIndices.Add(16);
            //mesh.TriangleIndices.Add(4);
            ////
            //mesh.TriangleIndices.Add(4);
            //mesh.TriangleIndices.Add(16);
            //mesh.TriangleIndices.Add(2);

            //mesh.TriangleIndices.Add(16);
            //mesh.TriangleIndices.Add(14);
            //mesh.TriangleIndices.Add(2);
            ////
            //mesh.TriangleIndices.Add(1);
            //mesh.TriangleIndices.Add(2);
            //mesh.TriangleIndices.Add(14);

            //mesh.TriangleIndices.Add(1);
            //mesh.TriangleIndices.Add(14);
            //mesh.TriangleIndices.Add(13);
            //////торец -
            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(20);
            //mesh.TriangleIndices.Add(12);

            //mesh.TriangleIndices.Add(0);
            //mesh.TriangleIndices.Add(8);
            //mesh.TriangleIndices.Add(20);
            ////
            //mesh.TriangleIndices.Add(8);
            //mesh.TriangleIndices.Add(11);
            //mesh.TriangleIndices.Add(20);

            //mesh.TriangleIndices.Add(11);
            //mesh.TriangleIndices.Add(23);
            //mesh.TriangleIndices.Add(20);
            ////
            //mesh.TriangleIndices.Add(11);
            //mesh.TriangleIndices.Add(22);
            //mesh.TriangleIndices.Add(23);


            //mesh.TriangleIndices.Add(10);
            //mesh.TriangleIndices.Add(22);
            //mesh.TriangleIndices.Add(11);
            ////
            //mesh.TriangleIndices.Add(10);
            //mesh.TriangleIndices.Add(9);
            //mesh.TriangleIndices.Add(22);

            //mesh.TriangleIndices.Add(9);
            //mesh.TriangleIndices.Add(21);
            //mesh.TriangleIndices.Add(22);
            ////
            //mesh.TriangleIndices.Add(9);
            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(21);

            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(9);
            //mesh.TriangleIndices.Add(7);
            ////
            //mesh.TriangleIndices.Add(19);
            //mesh.TriangleIndices.Add(7);
            //mesh.TriangleIndices.Add(1);

            //mesh.TriangleIndices.Add(1);
            //mesh.TriangleIndices.Add(13);
            //mesh.TriangleIndices.Add(19);
   
            mGeometry = new GeometryModel3D(mesh, new DiffuseMaterial(Brushes.Blue));///материал и цвет
         //   mGeometry = new GeometryModel3D(mesh, new SpecularMaterial(Brushes.DarkRed, 1));
            mGeometry.Transform = new Transform3DGroup();
            group.Children.Add(mGeometry);

    }

        private MeshGeometry3D AddPolygonMesh(MeshGeometry3D mesh, float x1, float y1, float z1, float x2, float y2, float z2, float x3, float y3, float z3, float x4, float y4, float z4)
        {
            mesh.Positions.Add(new Point3D(x1, y1, z1));        
            mesh.Positions.Add(new Point3D(x1, y1, z1));         
            mesh.Positions.Add(new Point3D(x1, y1, z1));           
            mesh.Positions.Add(new Point3D(x1, y1, z1));

            return mesh;
        }
        private void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            camera.Position = new Point3D(
                camera.Position.X,
                camera.Position.Y,
                camera.Position.Z - e.Delta / 250D);
        }
        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            mDown = false;
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed) return;
            mDown = true;
            Point pos = Mouse.GetPosition(viewport);
            mLastPos = new Point(
                    pos.X - viewport.ActualWidth / 2,
                    viewport.ActualHeight / 2 - pos.Y);
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (!mDown) return;
            Point pos = Mouse.GetPosition(viewport);
            Point actualPos = new Point(
                    pos.X - viewport.ActualWidth / 2,
                    viewport.ActualHeight / 2 - pos.Y);
            double dx = actualPos.X - mLastPos.X;
            double dy = actualPos.Y - mLastPos.Y;
            double mouseAngle = 0;

            if (dx != 0 && dy != 0)
            {
                mouseAngle = Math.Asin(Math.Abs(dy) /
                    Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2)));
                if (dx < 0 && dy > 0) mouseAngle += Math.PI / 2;
                else if (dx < 0 && dy < 0) mouseAngle += Math.PI;
                else if (dx > 0 && dy < 0) mouseAngle += Math.PI * 1.5;
            }
            else if (dx == 0 && dy != 0)
            {
                mouseAngle = Math.Sign(dy) > 0 ? Math.PI / 2 : Math.PI * 1.5;
            }
            else if (dx != 0 && dy == 0)
            {
                mouseAngle = Math.Sign(dx) > 0 ? 0 : Math.PI;
            }

            double axisAngle = mouseAngle + Math.PI / 2;

            Vector3D axis = new Vector3D(
                    Math.Cos(axisAngle) * 4,
                    Math.Sin(axisAngle) * 4, 0);

            double rotation = 0.02 *
                    Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            Transform3DGroup group = mGeometry.Transform as Transform3DGroup;
            QuaternionRotation3D r =
                 new QuaternionRotation3D(
                 new Quaternion(axis, rotation * 180 / Math.PI));
            group.Children.Add(new RotateTransform3D(r));

            mLastPos = actualPos;
        }
    }
}
