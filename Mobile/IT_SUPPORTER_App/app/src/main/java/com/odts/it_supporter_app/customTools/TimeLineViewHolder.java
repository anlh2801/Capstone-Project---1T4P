package com.odts.it_supporter_app.customTools;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.github.vipulasri.timelineview.TimelineView;
import com.odts.it_supporter_app.R;


public class TimeLineViewHolder extends RecyclerView.ViewHolder{
    TextView mDate;
    TextView mStatus;
    TextView mMessage;
    TimelineView mTimelineView;

    public TimeLineViewHolder(View itemView, int viewType) {
        super(itemView);

        mTimelineView = itemView.findViewById(R.id.time_marker);
        mDate = itemView.findViewById(R.id.text_timeline_date);
        mStatus = itemView.findViewById(R.id.text_timeline_title);
        mMessage = itemView.findViewById(R.id.text_timeline_message);
        mTimelineView.initLine(viewType);
    }
}
