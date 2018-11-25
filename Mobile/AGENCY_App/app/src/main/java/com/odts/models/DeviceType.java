package com.odts.models;

import com.google.gson.annotations.SerializedName;

import java.io.Serializable;

public class DeviceType implements Serializable {

    @SerializedName("DeviceTypeId")
    private Integer deviceTypeId;

    @SerializedName("DeviceTypeName")
    private String deviceTypeName;

    public DeviceType() {
    }

    public DeviceType(String deviceTypeName) {
        this.deviceTypeName = deviceTypeName;
    }

    public Integer getDeviceTypeId() {
        return deviceTypeId;
    }

    public void setDeviceTypeId(Integer deviceTypeId) {
        this.deviceTypeId = deviceTypeId;
    }

    public String getDeviceTypeName() {
        return deviceTypeName;
    }

    public void setDeviceTypeName(String deviceTypeName) {
        this.deviceTypeName = deviceTypeName;
    }

    @Override
    public String toString() {
        return deviceTypeName.toString();
    }
}
