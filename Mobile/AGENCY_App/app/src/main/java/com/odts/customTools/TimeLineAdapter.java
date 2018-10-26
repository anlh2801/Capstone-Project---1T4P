package com.odts.customTools;

import android.content.Context;
import android.support.v4.content.ContextCompat;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import com.github.vipulasri.timelineview.TimelineView;
import com.odts.models.Ticket;
import com.odts.utils.DateTimeUtils;
import com.odts.utils.Enums;
import com.odts.utils.VectorDrawableUtils;
import com.odts.activities.R;

import java.util.List;

public class TimeLineAdapter extends  RecyclerView.Adapter<TimeLineViewHolder> {
    private List<Ticket> mFeedList;
    private Context mContext;
    private LayoutInflater mLayoutInflater;

    public TimeLineAdapter(List<Ticket> feedList) {
        mFeedList = feedList;
    }

    @Override
    public int getItemViewType(int position) {
        return TimelineView.getTimeLineViewType(position,getItemCount());
    }

    @Override
    public TimeLineViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        mContext = parent.getContext();
        mLayoutInflater = LayoutInflater.from(mContext);
        View view;
        view = mLayoutInflater.inflate(R.layout.item_timeline_line_padding , parent, false);
        return new TimeLineViewHolder(view, viewType);
    }

    @Override
    public void onBindViewHolder(TimeLineViewHolder holder, int position) {

        Ticket timeLineModel = mFeedList.get(position);

        if(timeLineModel.getCrStatus() == Enums.RequestStatusEnum.Pending.getIntValue()) {
            holder.mTimelineView.setMarker(VectorDrawableUtils.getDrawable(mContext, R.drawable.ic_marker_inactive, android.R.color.darker_gray));
        } else if(timeLineModel.getCrStatus() ==  Enums.RequestStatusEnum.Processing.getIntValue()) {
            holder.mTimelineView.setMarker(VectorDrawableUtils.getDrawable(mContext, R.drawable.ic_marker_active, R.color.colorPrimary));
        } else {
            holder.mTimelineView.setMarker(ContextCompat.getDrawable(mContext, R.drawable.ic_marker), ContextCompat.getColor(mContext, R.color.colorPrimary));
        }

        if(!timeLineModel.getiTSupporterName().isEmpty()) {
            holder.mDate.setVisibility(View.VISIBLE);
            holder.mDate.setText(DateTimeUtils.parseDateTime(timeLineModel.getTicketEstimationTime(), "dd/MM/yyyy HH:mm", "hh:mm a, dd-MMM-yyyy"));
        }
        else
            holder.mDate.setVisibility(View.GONE);

        holder.mMessage.setText(timeLineModel.getiTSupporterName());
    }

    @Override
    public int getItemCount() {
        return (mFeedList!=null? mFeedList.size():0);
    }
}
