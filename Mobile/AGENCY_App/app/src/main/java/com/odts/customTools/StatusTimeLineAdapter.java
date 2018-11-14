package com.odts.customTools;

import android.content.Context;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.github.vipulasri.timelineview.TimelineView;
import com.odts.activities.R;
import com.odts.models.Request;
import com.odts.models.TimeLine;
import com.odts.utils.VectorDrawableUtils;

import java.util.List;

public class StatusTimeLineAdapter extends RecyclerView.Adapter<TimeLineViewHolder> {
    private List<TimeLine> mFeedList;
    private Context mContext;
    private LayoutInflater mLayoutInflater;

    public StatusTimeLineAdapter(List<TimeLine> feedList) {
        mFeedList = feedList;
    }

    @Override
    public int getItemViewType(int position) {
        return TimelineView.getTimeLineViewType(position, getItemCount());
    }

    @Override
    public TimeLineViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        mContext = parent.getContext();
        mLayoutInflater = LayoutInflater.from(mContext);
        View view;
        view = mLayoutInflater.inflate(R.layout.item_timeline_line_padding, parent, false);
        return new TimeLineViewHolder(view, viewType);
    }

    @Override
    public void onBindViewHolder(TimeLineViewHolder holder, int position) {

        TimeLine timeLineModel = mFeedList.get(position);

        if (timeLineModel.getStatus().equalsIgnoreCase("IT")) {
            holder.mTimelineView.setMarker(VectorDrawableUtils.getDrawable(mContext, R.drawable.ic_marker_inactive, android.R.color.darker_gray));
        } else if (timeLineModel.getStatus().equalsIgnoreCase("START")) {
            holder.mTimelineView.setMarker(VectorDrawableUtils.getDrawable(mContext, R.drawable.ic_marker_active, R.color.colorPrimary));
        } else {
            holder.mTimelineView.setMarker(ContextCompat.getDrawable(mContext, R.drawable.ic_marker), ContextCompat.getColor(mContext, R.color.colorPrimary));
        }

        if (!timeLineModel.getStatus().isEmpty()) {
            holder.mDate.setVisibility(View.VISIBLE);
//            holder.mDate.setText(DateTimeUtils.parseDateTime(timeLineModel.getCreateDate(), "dd/MM/yyyy HH:mm", "hh:mm a, dd-MMM-yyyy"));
            holder.mDate.setText(timeLineModel.getTime());
        } else
            holder.mDate.setVisibility(View.GONE);

        holder.mMessage.setText(timeLineModel.getStatus());
    }

    @Override
    public int getItemCount() {
        return (mFeedList != null ? mFeedList.size() : 0);
    }
}
