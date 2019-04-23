
/*int min(int a, int b)
{
  return a > b ? b : a;
}*/

 float getAngle(vec2 v1, vec2 v2){
    return acos((v1.x * v2.x + v1.y * v2.y)/(getVectorLength(v1) * getVectorLength(v2)));
 }

float getVectorLength(vec2 v){
  return sqrt(v.x*v.x + v.y*v.y);
}

 vec2 getDirVector(vec2 v){
  float len = getVectorLength(v);
  return {v.x/len, v.y/len};
 }
