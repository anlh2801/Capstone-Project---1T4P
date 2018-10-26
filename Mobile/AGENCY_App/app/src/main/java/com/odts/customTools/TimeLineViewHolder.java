package com.odts.customTools;

import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

import com.odts.activities.R;
import butterknife.BindView;
import butterknife.ButterKnife;

import com.github.vipulasri.timelineview.TimelineView;

public class TimeLineViewHolder extends RecyclerView.ViewHolder{
    @BindView(R.id.text_timeline_date)
    TextView mDate;
    @BindView(R.id.text_timeline_title)
    TextView mMessage;
    @BindView(R.id.time_marker)
    TimelineView mTimelineView;

    public TimeLineViewHolder(View itemView, int viewType) {
        super(itemView);

        ButterKnife.bind(this, itemView);
        mTimelineView.initLine(viewType);
    }
}
