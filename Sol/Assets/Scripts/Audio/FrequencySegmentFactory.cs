using System.Collections;

public class FrequencySegmentFactory {
    public static FrequencySegment MakeSegment(int segment){
        FrequencySegment newSegment = null;
        //needs to be expanded
        switch(segment){
            case 0:
                newSegment = new FrequencySegment(0, 5);
                break;
            case 1:
                newSegment = new FrequencySegment(13, 18);
                break;
            case 2:
                newSegment = new FrequencySegment(43, 48);
                break;
            default:
                newSegment = new FrequencySegment(43, 48);
                break;
        }

        return newSegment;
    }
}
