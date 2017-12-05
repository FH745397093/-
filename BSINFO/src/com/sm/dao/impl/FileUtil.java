package com.sm.dao.impl;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.io.OutputStream;
import java.io.PrintWriter;
import java.io.UnsupportedEncodingException;
import java.util.Enumeration;
import java.util.zip.ZipEntry;
import java.util.zip.ZipException;
import java.util.zip.ZipFile;
import sun.misc.BASE64Decoder;

/**
 * �ļ�������
 * 
 * @author Administrator
 * 
 */
public class FileUtil {
	public static long getFileLength(String fileName) {
		return new File(fileName).length();
	}

	/**
	 * ��Դ�ļ�д��SD��
	 * 
	 * @param context
	 * @param resourId
	 * @param path
	 * @param fileName
	 */
	// public static void writeResourToSD(Context context, int resourId, String
	// path, String fileName) {
	// InputStream is = context.getResources().openRawResource(resourId);
	// File cascadeDir = new File(path);
	// File mCascadeFile = new File(cascadeDir, fileName);
	//
	// try {
	// FileOutputStream os = new FileOutputStream(mCascadeFile);
	// byte[] buffer = new byte[4096];
	// int bytesRead;
	// while ((bytesRead = is.read(buffer)) != -1) {
	// os.write(buffer, 0, bytesRead);
	// }
	// is.close();
	// os.close();
	// } catch (IOException e) {
	// e.printStackTrace();
	// }
	// }

	/**
	 * д��Bitmap
	 * 
	 * @param bitmap
	 * @param fileSrc
	 * @return
	 */
	// public static boolean writeBitMap(Bitmap bitmap, String fileSrc) {
	// try {
	// File file = new File(fileSrc);
	// BufferedOutputStream bos = new BufferedOutputStream(new
	// FileOutputStream(file));
	//
	// bitmap.compress(Bitmap.CompressFormat.JPEG, 100, bos);// ��ͼƬѹ����������
	// bos.flush();// ˢ�´˻������������
	// bos.close();// �رմ���������ͷ�������йص�����ϵͳ��Դ
	// bitmap.recycle();// ����bitmap�ռ�
	// } catch (Exception e) {
	// System.out.println("Method:writeBitMap-Error:" + e.toString());
	// }
	//
	// return true;
	// }
	/**
	 * �����ֽ�д�ļ�
	 * 
	 * @param bytes
	 * @param fileNameWithPath
	 * @throws Exception
	 */
	public static void writeFileByByte(byte[] bytes, String fileNameWithPath) {
		try {
			OutputStream outputStream = new FileOutputStream(new File(
					fileNameWithPath), true);
			outputStream.write(bytes);
			outputStream.close();
		} catch (IOException e) {
			e.toString();
		}

	}

	/**
	 * ��ѹ������. ��zipFile�ļ���ѹ��folderPathĿ¼��.
	 * 
	 * @throws Exception
	 */
	public static int upZipFile(File zipFile, String folderPath)
			throws ZipException, IOException {
		// public static void upZipFile() throws Exception{
		ZipFile zfile = new ZipFile(zipFile);
		Enumeration zList = zfile.entries();
		ZipEntry ze = null;
		byte[] buf = new byte[1024];
		while (zList.hasMoreElements()) {
			ze = (ZipEntry) zList.nextElement();
			if (ze.isDirectory()) {
				String dirstr = folderPath + ze.getName();
				// dirstr.trim();
				dirstr = new String(dirstr.getBytes("8859_1"), "GB2312");
				File f = new File(dirstr);
				f.mkdir();
				continue;
			}
			OutputStream os = new BufferedOutputStream(new FileOutputStream(
					getRealFileName(folderPath, ze.getName())));
			InputStream is = new BufferedInputStream(zfile.getInputStream(ze));
			int readLen = 0;
			while ((readLen = is.read(buf, 0, 1024)) != -1) {
				os.write(buf, 0, readLen);
			}
			is.close();
			os.close();
		}
		zfile.close();
		return 0;
	}

	/**
	 * ������Ŀ¼������һ�����·������Ӧ��ʵ���ļ���.
	 * 
	 * @param baseDir
	 *            ָ����Ŀ¼
	 * @param absFileName
	 *            ���·������������ZipEntry�е�name
	 * @return java.io.File ʵ�ʵ��ļ�
	 */
	public static File getRealFileName(String baseDir, String absFileName) {
		String[] dirs = absFileName.split("/");
		File ret = new File(baseDir);
		String substr = null;
		if (dirs.length > 1) {
			for (int i = 0; i < dirs.length - 1; i++) {
				substr = dirs[i];
				try {
					substr = new String(substr.getBytes("8859_1"), "GB2312");

				} catch (UnsupportedEncodingException e) {
					e.printStackTrace();
				}
				ret = new File(ret, substr);

			}
			if (!ret.exists())
				ret.mkdirs();
			substr = dirs[dirs.length - 1];
			try {
				// substr.trim();
				substr = new String(substr.getBytes("8859_1"), "GB2312");
			} catch (UnsupportedEncodingException e) {
				e.printStackTrace();
			}

			ret = new File(ret, substr);
			return ret;
		}
		return ret;
	}

	/**
	 * ɾ��ĳ���ļ����µ������ļ��к��ļ�
	 * 
	 * @param delpath
	 *            String
	 * @throws FileNotFoundException
	 * @throws IOException
	 * @return boolean
	 */
	public static boolean deletefile(String delpath) throws Exception {
		try {

			File file = new File(delpath);
			// ���ҽ����˳���·������ʾ���ļ������� ��һ��Ŀ¼ʱ������ true
			if (!file.isDirectory()) {
				file.delete();
			} else if (file.isDirectory()) {
				String[] filelist = file.list();
				for (int i = 0; i < filelist.length; i++) {
					File delfile = new File(delpath + "\\" + filelist[i]);
					if (!delfile.isDirectory()) {
						delfile.delete();
						System.out
								.println(delfile.getAbsolutePath() + "ɾ���ļ��ɹ�");
					} else if (delfile.isDirectory()) {
						deletefile(delpath + "\\" + filelist[i]);
					}
				}
				System.out.println(file.getAbsolutePath() + "ɾ���ɹ�");
				file.delete();
			}

		} catch (FileNotFoundException e) {
			throw new Exception("�ļ�ɾ��ʧ��"+ e.toString());
		}
		return true;
	}

	/**
	 * �����ļ�
	 * 
	 * @throws Exception
	 * 
	 * @throws IOException
	 */
	public static boolean creatFile(String fileName) throws Exception {

		try {
			File filename = new File(fileName);
			if (!filename.exists()) {
				filename.createNewFile();
			}
		} catch (IOException e) {
			throw new Exception("�ļ�����ʧ��"+ e.toString());
		}

		return true;
	}

	/**
	 * ����Ŀ¼
	 * 
	 * @throws IOException
	 */
	public static boolean creatDirs(String filePath) {
		boolean flag = false;
		File filepath = new File(filePath);
		if (!filepath.exists()) {
			flag = filepath.mkdirs();
		}
		return flag;
	}

	/**
	 * �ļ��Ƿ����
	 * 
	 * @throws IOException
	 */
	public static boolean fileExists(String filePath) {
		File filepath = new File(filePath);
		return filepath.exists();
	}

	/**
	 * ��д�ļ�����
	 * 
	 * @param fileName
	 * @param fileContent
	 * @return
	 * @throws Exception
	 */
	public static void continueWriteContent(String fileName, String fileContent)
			throws Exception {
		try {
			File file = new File(fileName);
			BufferedWriter bufferedWriter = new BufferedWriter(new FileWriter(
					file, true));
			bufferedWriter.write(fileContent);
			bufferedWriter.flush();
			bufferedWriter.close();
		} catch (Exception e) {
			throw new Exception("�ļ���дʧ��"+ e.toString());
		}

	}

	/**
	 * ��base64תΪbyteд���ļ�
	 * 
	 * @param imgTxtPath
	 * @param imgPath
	 * @return
	 * @throws Exception
	 */
	public static boolean writeFileWithBase64(String imgTxtPath, String imgPath)
			throws Exception {
		byte[] bytes;
		try {

			String base64Str = FileUtil.readFileContent(imgTxtPath);
			bytes = new BASE64Decoder().decodeBuffer(base64Str);

			creatFile(imgPath);
			FileUtil.writeFileByByte(bytes, imgPath);
		} catch (IOException e) {
			throw new Exception("base64תbyteд���ļ�ʧ��" + e.toString());
		}
		return true;
	}

	/**
	 * д�ļ�����
	 * 
	 * @param newStr
	 *            ������
	 * @throws IOException
	 */
	public static boolean writeTxtFile(String fileName, String newStr)
			throws IOException {
		// �ȶ�ȡԭ���ļ����ݣ�Ȼ�����д�����
		boolean flag = false;
		String filein = newStr + "\r\n";
		String temp = "";

		FileInputStream fis = null;
		InputStreamReader isr = null;
		BufferedReader br = null;

		FileOutputStream fos = null;
		PrintWriter pw = null;
		try {
			// �ļ�·��
			File file = new File(fileName);
			// ���ļ�����������
			fis = new FileInputStream(file);
			isr = new InputStreamReader(fis);
			br = new BufferedReader(isr);
			StringBuffer buf = new StringBuffer();

			// ������ļ�ԭ�е�����
			for (int j = 1; (temp = br.readLine()) != null; j++) {
				buf = buf.append(temp);
				// System.getProperty("line.separator")
				// ������֮��ķָ��� �൱�ڡ�\n��
				buf = buf.append(System.getProperty("line.separator"));
			}
			buf.append(filein);

			fos = new FileOutputStream(file);
			pw = new PrintWriter(fos);
			pw.write(buf.toString().toCharArray());
			pw.flush();
			flag = true;
		} catch (IOException e1) {
			throw e1;
		} finally {
			if (pw != null) {
				pw.close();
			}
			if (fos != null) {
				fos.close();
			}
			if (br != null) {
				br.close();
			}
			if (isr != null) {
				isr.close();
			}
			if (fis != null) {
				fis.close();
			}
		}
		return flag;
	}

	/**
	 * ��ȡ�ļ������ı�����
	 * 
	 * @param fileName
	 * @return
	 * @throws IOException
	 */
	public static String readFileContent(String fileName) throws IOException {
		File file = new File(fileName);
		BufferedReader bf = new BufferedReader(new FileReader(file));
		String content = "";
		StringBuilder sb = new StringBuilder();
		while (content != null) {
			content = bf.readLine();
			if (content == null) {
				break;
			}
			sb.append(content.trim());
		}
		bf.close();
		return sb.toString();
	}

	/**
	 * ��ȡ�ļ��ֽ�
	 * 
	 * @return
	 * @throws FileNotFoundException
	 * @throws IOException
	 */
	public static byte[] readFileByte(String filePath)
			throws FileNotFoundException, IOException {
		BufferedInputStream in = new BufferedInputStream(new FileInputStream(
				filePath));
		ByteArrayOutputStream out = new ByteArrayOutputStream(1024);
		byte[] temp = new byte[1024];
		int size = 0;
		while ((size = in.read(temp)) != -1) {
			out.write(temp, 0, size);
		}
		in.close();

		byte[] content = out.toByteArray();
		return content;
	}

	/**
	 * д�������־
	 * 
	 * @param filePath
	 * @param projectid
	 * @param exception
	 */
	public static void writeErrLog(String filePath, String exception) {
		try {
			String fileName = StringUtil.getGuid() + ".log";
			String fileFullName = filePath + "/log/" + fileName;
			FileUtil.creatFile(fileFullName);
			FileUtil.continueWriteContent(fileFullName, exception);
		} catch (Exception e) {
			e.printStackTrace();
		}

	}
}
