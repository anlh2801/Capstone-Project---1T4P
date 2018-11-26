package com.odts.activities;

import android.app.DatePickerDialog;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;

import com.odts.models.Device;
import com.odts.models.DeviceType;
import com.odts.models.ServiceITSupport;
import com.odts.services.AgencyService;
import com.odts.services.DeviceService;
import com.odts.services.ServiceITSupportService;
import com.odts.utils.CallBackData;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

public class AddDeviceActivity extends AppCompatActivity {
    ServiceITSupportService _serviceITSupportService;
    int agencyID;
    int deviceTypeID;
    AgencyService agencyService;
    DeviceService deviceService;
    Spinner deviceType;
    Button btnSave, btnCancel;
    EditText editTextSetting, editdeviceName, editdeviceCode, editTextIp, editTextPortTT;
    int mYear, mMonth, mDay;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_device);
        SharedPreferences share = getSharedPreferences("ODTS", MODE_PRIVATE);
        agencyID = share.getInt("agencyId", 0);
        getAllServiceITSupportForAgency(agencyID);
        btnSave = (Button) findViewById(R.id.btnSaveDevice);
        btnCancel = (Button) findViewById(R.id.btnCancle);
        deviceType = (Spinner) findViewById(R.id.spinnerDeviceType);
        editdeviceName = (EditText) findViewById(R.id.editTextDeviceName);
        editdeviceCode = (EditText) findViewById(R.id.editTextDeviceCode);
        editTextIp = (EditText) findViewById(R.id.editTextIp);
        editTextPortTT = (EditText) findViewById(R.id.editTextPortTT);
        btnSave.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                createDevice();
            }
        });
        btnCancel.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                finish();
            }
        });
        editTextSetting = (EditText) findViewById(R.id.editTextSetting);
        editTextSetting.setFocusable(false);
        editTextSetting.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                final Calendar c = Calendar.getInstance();
                mYear = c.get(Calendar.YEAR);
                mMonth = c.get(Calendar.MONTH);
                mDay = c.get(Calendar.DAY_OF_MONTH);


                DatePickerDialog datePickerDialog = new DatePickerDialog(AddDeviceActivity.this,
                        new DatePickerDialog.OnDateSetListener() {
                            @Override
                            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                                editTextSetting.setText(dayOfMonth + "/" + (monthOfYear + 1) + "/" + year);
                            }
                        }, mYear, mMonth, mDay);
                datePickerDialog.show();
            }
        });


    }

    private void getAllServiceITSupportForAgency(final int agencyId) {
        _serviceITSupportService = new ServiceITSupportService();
        deviceService = new DeviceService();
        final Spinner spinner = (Spinner) findViewById(R.id.spinnerDeviceType);
//        final ArrayAdapter<DeviceType> dataAdapter = null;
        final List<DeviceType> categories = new ArrayList<>();
        categories.add(new DeviceType("Chọn loại thiết bị"));
        _serviceITSupportService.getAllServiceITSupport(AddDeviceActivity.this, agencyId, new CallBackData<ArrayList<ServiceITSupport>>() {
            @Override
            public void onSuccess(ArrayList<ServiceITSupport> serviceITSupports) {
                for (final ServiceITSupport item : serviceITSupports) {
                    deviceService = new DeviceService();
                    deviceService.getAllDeviceTypeByServiceId(AddDeviceActivity.this, item.getServiceITSupportId(), new CallBackData<ArrayList<DeviceType>>() {
                        @Override
                        public void onSuccess(ArrayList<DeviceType> deviceTypes) {
                            for (final DeviceType item : deviceTypes) {
                                categories.add(item);
                                final ArrayAdapter<DeviceType> dataAdapter = new ArrayAdapter<DeviceType>(AddDeviceActivity.this, android.R.layout.simple_spinner_item, categories){
                                    @Override
                                    public boolean isEnabled(int position) {
                                        if (position == 0) {
                                            // Disable the first item from Spinner
                                            // First item will be use for hint
                                            return false;
                                        } else {
                                            return true;
                                        }
                                    }
                                    @Override
                                    public View getDropDownView(int position, View convertView, ViewGroup parent) {
                                        View view = super.getDropDownView(position, convertView, parent);
                                        TextView tv = (TextView) view;
                                        if (position == 0) {
                                            // Set the hint text color gray
                                            tv.setTextColor(Color.GRAY);
                                        } else {
                                            tv.setTextColor(Color.BLACK);
                                        }
                                        return view;
                                    }
                                };
                                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                                spinner.setAdapter(dataAdapter);
                                spinner.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                                    @Override
                                    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
                                        if(i > 0) {
                                            DeviceType deviceType = (DeviceType) adapterView.getSelectedItem();
                                            deviceTypeID = deviceType.getDeviceTypeId();
                                        }


                                    }

                                    @Override
                                    public void onNothingSelected(AdapterView<?> adapter) {
                                    }
                                });
                            }
                        }

                        @Override
                        public void onFail(String message) {

                        }
                    });
                }

            }

            @Override
            public void onFail(String message) {

            }
        });
    }

    private void getAllDeviceTypeByServiceId(int serviceID) {
//        deviceService = new DeviceService();
//        final Spinner spinner = (Spinner) findViewById(R.id.spinnerDeviceType);
//        final List<DeviceType> categories = new ArrayList<>();
//        deviceService.getAllDeviceTypeByServiceId(AddDeviceActivity.this, serviceID, new CallBackData<ArrayList<DeviceType>>() {
//            @Override
//            public void onSuccess(ArrayList<DeviceType> deviceTypes) {
////                categories.add(deviceType);
//                for (final DeviceType item : deviceTypes) {
//                    categories.add(item);
//                }
////                categories = deviceTypes;
//                final ArrayAdapter<DeviceType> dataAdapter = new ArrayAdapter<DeviceType>(AddDeviceActivity.this, android.R.layout.simple_spinner_item, categories);
//                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//                spinner.setAdapter(dataAdapter);
//            }
//
//            @Override
//            public void onFail(String message) {
//
//            }
//        });

    }

    private void createDevice() {
        Device device = new Device();
        device.setAgencyId(agencyID);
        device.setDeviceTypeId(deviceTypeID);
        device.setDeviceName(editdeviceName.getText().toString());
        device.setDeviceCode(editdeviceCode.getText().toString());
        device.setGuarantyStartDate("24/11/2018");
        device.setGuarantyEndDate("24/11/2018");
        device.setIp(editTextIp.getText().toString());
        device.setPort(editTextPortTT.getText().toString());
        device.setSettingDate(editTextSetting.getText().toString());
        agencyService = new AgencyService();
        agencyService.createDevice(AddDeviceActivity.this, device);
    }
}
