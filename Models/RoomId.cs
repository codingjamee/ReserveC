using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Reservoom.Models
{
    public class RoomId
    {
        public int FloorNumber
        {
            get;
        }
        public int RoomNumber
        {
            get;
        }

        public RoomId(int floorNumber, int roomNumber)
        {
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
        }


        // ToString 사용예시
        // 1. 문자열 보간/연결 시
        // string message = $"고객님은 {roomId} 방에 체크인하셨습니다.";
        // 2. 콘솔 출력이나 로깅 시
        // 3.  UI 요소에 바인딩 시 (WPF/XAML 등)
        //<TextBlock Text="{Binding CurrentRoom}" />
        // 4. 디버깅 시

        public override string ToString()
        {
            return $"{FloorNumber}{RoomNumber}";
        }

        public override bool Equals(object obj)
        {
            return obj is RoomId id &&
                   FloorNumber == id.FloorNumber &&
                   RoomNumber == id.RoomNumber;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17; //소수
                hash = hash * 23 + FloorNumber.GetHashCode(); //소수(17) * 소수(23)
                hash = hash * 23 + RoomNumber.GetHashCode();
                return hash;
            }
        }

        //C#에서 == 와 != 오버로딩의 규칙
        //정적 메서드로 선언: static 키워드 사용
        //쌍으로 구현: ==를 오버로드하면 !=도 함께 오버로드해야 함
        //Equals 메서드와 일관성: ==와 Object.Equals()는 같은 결과를 내야 함
        //GetHashCode와의 관계: 두 객체가 ==로 같다면 GetHashCode()도 같은 값을 반환해야 함
        public static bool operator ==(RoomId roomId1, RoomId roomId2)
        {
            if (roomId1 is null && roomId2 is null)
            {
                return true;
            }

            return roomId1 != null && roomId1.Equals(roomId2);
        }

        public static bool operator !=(RoomId roomId1, RoomId roomId2)
        {
            return !roomId1.Equals(roomId2);
        }
    }
}
