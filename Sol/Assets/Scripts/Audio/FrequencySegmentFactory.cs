using System.Collections;

public class FrequencySegmentFactory {
    public static FrequencySegment MakeSegment(int segment){
        FrequencySegment newSegment = null;
        //needs to be expanded
        switch(segment){
            case 0:
                //octave 0
                newSegment = new FrequencySegment(0, 2);
                break;
            case 1:
                //octave 1
                newSegment = new FrequencySegment(2, 3);
                break;
            case 2:
                //octabe 2
                newSegment = new FrequencySegment(3, 6);
                break;
            case 3:
                //octave 3
                //...
                newSegment = new FrequencySegment(6, 11);
                break;
            case 4:
                newSegment = new FrequencySegment(12, 21);
                break;
            case 5:
                newSegment = new FrequencySegment(22, 42);
                break;
            case 6:
                newSegment = new FrequencySegment(44, 84);
                break;
            case 7:
                newSegment = new FrequencySegment(89, 169);
                break;
            case 8:
                newSegment = new FrequencySegment(179, 338);
                break;
            default:
                newSegment = new FrequencySegment(43, 48);
                break;
        }

        return newSegment;
    }
}
