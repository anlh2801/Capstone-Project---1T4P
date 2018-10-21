package com.odts.customTools;

import android.content.Context;
import android.content.Intent;
import android.support.v4.content.LocalBroadcastManager;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.odts.activities.R;
import com.odts.models.Device;

import java.util.List;

public class DeviceAdapter extends RecyclerView.Adapter<DeviceAdapter.ViewHolder> {

    private List<Device> mItems;
    private ItemListener mListener;
    private Context context;

    public DeviceAdapter(List<Device> items, ItemListener listener, Context context) {
        mItems = items;
        mListener = listener;
        this.context = context;
    }

    public void setListener(ItemListener listener) {
        mListener = listener;
    }

    @Override
    public ViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        return new ViewHolder(LayoutInflater.from(parent.getContext())
                .inflate(R.layout.device_item_list, parent, false));
    }

    @Override
    public void onBindViewHolder(ViewHolder holder, int position) {
        holder.setData(mItems.get(position));
    }

    @Override
    public int getItemCount() {
        return mItems.size();
    }

    public class ViewHolder extends RecyclerView.ViewHolder implements View.OnClickListener {

        public TextView txtDeviceCode;
        public TextView txtDeviceName;

        public Button btnAddDevice;

        public Device item;

        public ViewHolder(View itemView) {
            super(itemView);
            itemView.setOnClickListener(this);

            txtDeviceCode = (TextView) itemView.findViewById(R.id.txtDeviceCode);
            txtDeviceName = (TextView) itemView.findViewById(R.id.txtDeviceName);

            btnAddDevice = (Button) itemView.findViewById(R.id.btnAddDevice);

        }

        public void setData(final Device item) {
            this.item = item;
            txtDeviceCode.setText(item.getDeviceCode());
            txtDeviceName.setText(item.getDeviceName());
            btnAddDevice.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    Intent intent = new Intent("custom-message");
                    intent.putExtra ("name",item.getDeviceName());
                    LocalBroadcastManager.getInstance(context).sendBroadcast(intent);
                }
            });
        }

        @Override
        public void onClick(View v) {
            if (mListener != null) {
                mListener.onItemClick(item);
            }
        }
    }

    public interface ItemListener {
        void onItemClick(Device item);
    }
}
