package com.odts.models;

import com.google.gson.annotations.SerializedName;

public class ListRequest {
    @SerializedName("RequestId")
    private Integer requestId;
    @SerializedName("RequestName")
    private String requestName;
    @SerializedName("CreateDate")
    private String createDate;

    public ListRequest() {
    }

    public Integer getRequestId() {
        return requestId;
    }

    public void setRequestId(Integer requestId) {
        this.requestId = requestId;
    }

    public String getRequestName() {
        return requestName;
    }

    public void setRequestName(String requestName) {
        this.requestName = requestName;
    }

    public String getCreateDate() {
        return createDate;
    }

    public void setCreateDate(String createDate) {
        this.createDate = createDate;
    }

}
