using System;

namespace MathLibrary
{
    class Vector
    {
        int size;
        float[] elements;

        public Vector(int vector_size)
        {
            this.size = vector_size;
            this.elements = new float[this.size];
        }

        #region
        public static Vector operator +(Vector a, Vector b)
        {
            if (a.size != b.size)  throw new Exception("Vectors have a different size"); //Catching errors

            Vector vector_out = new Vector(a.size);

            for(int i = 0; i < a.elements.Length; i++)
            {
                vector_out.elements[i] = a.elements[i] + b.elements[i];
            }

            return vector_out; 
        }

        public static Vector operator -(Vector a, Vector b)
        {
            if (a.size != b.size) throw new Exception("Vectors have a different size"); //Catching errors
            Vector vector_out = new Vector(a.size);

            for (int i = 0; i < a.elements.Length; i++)
            {
                vector_out.elements[i] = a.elements[i] - b.elements[i];
            }

            return vector_out;
        }

        public static Vector operator *(float a, Vector b)  //Skalar Product
        {
            Vector vector_out = new Vector(b.size);

            for(int i = 0; i < b.elements.Length; i++)
            {
                vector_out.elements[i] = b.elements[i] * a;
            }

            return vector_out;
        }

        public static Vector operator *(Vector a, Vector b) //Cross Product
        {
            if (a.size != b.size) throw new Exception("Vectors have a different size"); //Catching errors
            Vector vector_out = new Vector(a.size);
            if (a.size != 3) throw new Exception("Cant calculate the crossproduct for vectors that arent 3D");
            int index = 1;

            for(int i = 0; i < ((a.elements.Length * 2) -3); i++)
            {
                vector_out.elements[i] = ((a.elements[index] * b.elements[index + 1]) - (a.elements[index + 1] * b.elements[index])); //Basic formula for CrossProduct
                if(index == a.elements.Length -1) { index = 0; } else { index += 1; }
            }

            return vector_out;
        }

        private float DotProduct(Vector a, Vector b) //Dot Product
        {
            if (a.size != b.size) throw new Exception("Vectors have a different size"); //Catching errors
            float value = 0f;

            for (int i = 0; i < a.elements.Length; i++)
            {
                value += a.elements[i] * b.elements[i];
            }

            return value;
        }
        #endregion
    }


}
